using System.IO.Compression;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using Emgu.CV.ML.Structure;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;


namespace TrafficSignRecognition
{
    public class NeuralNetwork
    {
        private const int N_INPUTS = 63;
        private const int N_OUTPUTS = 4;

        public IList<NeuralNetworkInput> Inputs { get; private set; }

        private ANN_MLP network;

        private void Teach()
        {
            int trainSampleCount = Inputs.Count();

            #region Generate the traning data and classes
            Matrix<float> trainData = new Matrix<float>(trainSampleCount, N_INPUTS);
            Matrix<float> trainClasses = new Matrix<float>(trainSampleCount, N_OUTPUTS);

            for (int i = 0; i < Inputs.Count(); i++)
            {
                for (int j = 0; j < N_INPUTS; j++)
                {
                    trainData.Data[i, j] = (float)Inputs[i].GetValueByIndex(j);
                }
                trainClasses.Data[i, (int)Inputs[i].GetTrafficSignType()] = 1.0f;
            }
            #endregion

            Matrix<int> layerSize = new Matrix<int>(new int[] { N_INPUTS, 64, N_OUTPUTS });

            MCvANN_MLP_TrainParams parameters = new MCvANN_MLP_TrainParams();
            parameters.term_crit = new MCvTermCriteria(100, 1.0e-8);
            parameters.train_method = Emgu.CV.ML.MlEnum.ANN_MLP_TRAIN_METHOD.BACKPROP;
            parameters.bp_dw_scale = 0.1;
            parameters.bp_moment_scale = 0.1;

            network = new ANN_MLP(layerSize, Emgu.CV.ML.MlEnum.ANN_MLP_ACTIVATION_FUNCTION.SIGMOID_SYM, 1.0, 1.0);

            Matrix<float> je_ne_sais_quoi_a = null;
            Matrix<int> je_ne_sais_quoi_b = null;

            Stopwatch t = new Stopwatch();
            t.Start();
            network.Train(trainData, trainClasses, je_ne_sais_quoi_a, je_ne_sais_quoi_b, parameters, Emgu.CV.ML.MlEnum.ANN_MLP_TRAINING_FLAG.DEFAULT);
            t.Stop();

            MessageBox.Show("Nauczono sieć w czasie " + t.ElapsedMilliseconds + " ms");
        }

        /// <summary>
        /// Na podstawie odpowiedzi sieci neuronowej przypisuje do danych wejsciowych jakis znak
        /// </summary>
        public TrafficSignType Predict(NeuralNetworkInput inp)
        {
            Matrix<float> sample = new Matrix<float>(1, N_INPUTS);
            Matrix<float> prediction = new Matrix<float>(1, N_OUTPUTS);

            for (int j = 0; j < N_INPUTS; j++)
            {
                sample.Data[0, j] = (float)inp.GetValueByIndex(j);
            }

            network.Predict(sample, prediction);

            int ind = (int)TrafficSignType.Unrecognized;
            float maxProb = float.MinValue;

            for (int i = 0; i < N_OUTPUTS; i++)
            {
                if (prediction.Data[0, i] >= maxProb && prediction.Data[0, i] > 1.0f)
                {
                    ind = i;
                    maxProb = prediction.Data[0, i];
                }
            }

            return (TrafficSignType)ind;
        }

        /// <summary>
        /// Tworzy nową sieć i uczy ją na podstawie zbioru treningowego spakowanego w pliku DANE_TRENINGOWE.zip
        /// </summary>
        public NeuralNetwork()
        {
            const string trainingSetZipFilename = @"DANE_TRENINGOWE.zip";
            Inputs = new List<NeuralNetworkInput>();

            using (ZipArchive archive = ZipFile.OpenRead(trainingSetZipFilename))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(entry.FullName, true);
                    Inputs.Add(new NeuralNetworkInput(Path.GetDirectoryName(Application.ExecutablePath) + "\\" + entry.FullName));
                    File.Delete(entry.FullName);
                }
            }

            Teach();
        }

        /// <summary>
        /// Directory = sciezka folderu w ktorym sa pliki z obrazkami do przetworzenia.
        /// </summary>
        public NeuralNetwork(string directory)
        {
            Inputs = new List<NeuralNetworkInput>();

            foreach (var filepath in Directory.EnumerateFiles(directory))
            {
                Inputs.Add(new NeuralNetworkInput(filepath));
            }

            Teach();
        }
    }

    public class NeuralNetworkInput
    {
        int[] Rows = new int[30];
        int[] Cols = new int[30];
        double R;
        double G;
        double B;
        TrafficSignType trafficSignType = TrafficSignType.Unrecognized;

        double[] uniform = new double[63];


        public TrafficSignType GetTrafficSignType()
        {
            return trafficSignType;
        }

        public double GetValueByIndex(int i)
        {
            return uniform[i];
        }


        public NeuralNetworkInput(ImageInfo ii, TrafficSignType tt = TrafficSignType.Unrecognized)
        {
            for (var i = 0; i < 30; i++)
            {
                for (var j = 0; j < 30; j++)
                {
                    Rows[i] += ii.Image[i, j].Intensity > 0.5 ? 1 : 0;
                    Cols[i] += ii.Image[j, i].Intensity > 0.5 ? 1 : 0;
                }
            }

            R = ii.R;
            G = ii.G;
            B = ii.B;

            trafficSignType = tt;
            this.makeArray();
        }

        public NeuralNetworkInput(string filename)
        {
            Image<Gray, byte> image = new Image<Gray, byte>(filename);

            for (var i = 0; i < 30; i++)
            {
                for (var j = 0; j < 30; j++)
                {
                    Rows[i] += image[i, j].Intensity > 0.5 ? 1 : 0;
                    Cols[i] += image[j, i].Intensity > 0.5 ? 1 : 0;
                }
            }

            // 17_droga_z_pierw_6_141,14_110,266666666667_73,5122222222222.bmp
            var regex = @"\\\d*_(.*)_\d*_([\d,\,]*)_([\d,\,]*)_([\d,\,]*)[.]";
            var matches = Regex.Matches(filename, regex);
            R = Double.Parse(matches[0].Groups[2].Value);
            G = Double.Parse(matches[0].Groups[3].Value);
            B = Double.Parse(matches[0].Groups[4].Value);

            trafficSignType = TrafficSignParser.ParseTrafficSignType(matches[0].Groups[1].Value);
            this.makeArray();
        }

        private void makeArray()
        {
            for (var i = 0; i < 30; i++)
            {
                uniform[i] = (double)Rows[i];
            }

            for (var i = 0; i < 30; i++)
            {
                uniform[30 + i] = (double)Cols[i];
            }

            uniform[60] = R;
            uniform[61] = G;
            uniform[62] = B;
        }
    }

    public class TrafficSignParser
    {
        public static TrafficSignType ParseTrafficSignType(string s)
        {
            switch (s.ToLower())
            {
                case "ustap_pierwsz": return TrafficSignType.UstapPierwszenstwa;
                case "droga_z_pierw": return TrafficSignType.DrogaZPierwszenstwem;
                case "zakaz_wjazdu": return TrafficSignType.ZakazWjazdu;
                default: return TrafficSignType.Unrecognized;
            }
        }
    }

    public enum TrafficSignType
    {
        Unrecognized = 0,
        UstapPierwszenstwa = 1,
        DrogaZPierwszenstwem = 2,
        ZakazWjazdu = 3
    }
}
