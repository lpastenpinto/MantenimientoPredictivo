using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Accord.MachineLearning;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using Accord.Statistics.Analysis;
using Accord.Statistics.Formats;
using System.Data;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mantenimiento_Predictivo.Clases
{
    class Serializar
    {
        public void serializar(DecisionTree tree)
        {
            FileStream stream = new FileStream("arbol.txt", FileMode.Create);
            BinaryFormatter formater = new BinaryFormatter();
            formater.Serialize(stream, tree);
            stream.Close();

        }

        public DecisionTree deserializar(string nombre)
        {
            FileStream stream = new FileStream(nombre+".txt", FileMode.Open);
            DecisionTree tree = null;
            BinaryFormatter formater = new BinaryFormatter();
            tree = (DecisionTree)(formater.Deserialize(stream));
            return tree;
        }
    }
}
