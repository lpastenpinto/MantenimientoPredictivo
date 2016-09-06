using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

  class PerceptronMulticapa
    {
        public double[] entradaX;     
      
        private double[, ,] Pesos_W;     
       
        private List<double[]> activacionNeuronal = new List<double[]>();
        private List<double[]> umbralesNeuronal = new List<double[]>();
        private double[,] delta;
        private double alfa = 0.7;
        private int numCapasOcultas;
        private int numX;      
        private int numNeuro;

        public PerceptronMulticapa(int Nx)
        {
            numCapasOcultas = 1;
            numX = Nx;
            numNeuro = Nx;
            entradaX = new double[Nx];
            Pesos_W = new double[numX, numX, numCapasOcultas + 1];
            delta = new double[numCapasOcultas + 1, numX];

        }
        public PerceptronMulticapa(double[] X, int numOcultas)
        {
            numCapasOcultas = numOcultas;
            numX = X.Length;
            //numX = 3;
            numNeuro = numX;
            entradaX = X;

            Pesos_W = new double[X.Length, X.Length, numOcultas + 1];
            Random ran=new Random();
            for (int k = 0; k < numCapasOcultas;k++ )
                for (int j = 0; j < numNeuro; j++)
                    for (int i = 0; i < numX; i++)
                        Pesos_W[i, j, k] = ran.NextDouble();            
            delta = new double[numCapasOcultas + 1, numX];

            for (int i = 0; i < numOcultas + 1; i++)
                activacionNeuronal.Add(new double[numNeuro]);
            activacionNeuronal.Add(new double[1] { 0 });
            for (int i = 0; i < numOcultas; i++)
                umbralesNeuronal.Add(new double[numNeuro]);
            umbralesNeuronal.Add(new double[1] { 0 });
            this.cargarPesos(".\\Pesos_ini.txt");
        }
        public PerceptronMulticapa(double[] X, int numOcultas, List<double[]> actNeuro, List<double[]> umbralesNeuro, double[, ,] PesosW)
        {
            numCapasOcultas = numOcultas;
            numX = X.Length;
            numNeuro = numX;
            entradaX = X;
            Pesos_W = PesosW;
            delta = new double[numCapasOcultas + 1, numX];
            umbralesNeuronal = umbralesNeuro;
            activacionNeuronal = actNeuro;
        }
        double[, ,] getPesos()
        {
            return Pesos_W;
        }
        public void  cargarPesos(string ruta)
        {            
            StreamReader lector = new StreamReader(ruta);
            string linea;
            double[, ,] pesos;
            double[] umbral;
            List<double[]> umbrales = new List<double[]>();;
            try
            {
                linea = lector.ReadLine();
                double[] aux;
                if (linea != null)
                {
                    //======ARMAR RED====================================================
                    int numIn = Convert.ToInt16(linea.ToString());
                    linea = lector.ReadLine();
                    int numCO = Convert.ToInt16(linea.ToString());
                    pesos = new double[numIn, numIn, numCO + 1];
                    aux = new double[numIn * numIn * numCO + numIn * numCO + numIn + 2];
                    Console.WriteLine("numX :" + numIn + " numCO :" + numCO);
                    delta = new double[numCO + 1, numIn];
                    activacionNeuronal.Clear();
                    for (int i = 0; i < numCO+1 ; i++)
                        activacionNeuronal.Add(new double[numIn]);
                    activacionNeuronal.Add(new double[1] { 0 });
                    for (int i = 0; i < numCO; i++)
                    {
                        double[] um = new double[numIn];
                        umbralesNeuronal.Add(um);
                    }
                    umbralesNeuronal.Add(new double[1] { 0 });
                    //=============================================================
                    int x = 0;
                    linea = lector.ReadLine();
                    while (linea != null && linea != "")
                    {
                      //  Console.WriteLine("salida " + linea.ToString());
                        aux[x] = Convert.ToDouble(linea.ToString().Replace('.', ','));
                        x++;
                        linea = lector.ReadLine();
                    }
                    x = 0;
                    for (int k = 0; k < numCO; k++)
                    {
                        umbral = new double[numIn];
                        for (int j = 0; j < numIn; j++)
                        {
                            umbral[j] = aux[x];

                            for (int i = 0; i < numIn; i++)
                            {
                                x++;
                                pesos[i, j, k] = aux[x];
                            }
                            x++;
                        }
                        umbrales.Add(umbral);
                    }
                    umbral = new double[1];
                    umbral[0] = aux[x];
                    umbrales.Add(umbral);
                    for (int i = 0; i < numIn; i++)
                    {
                        // Console.WriteLine("ki 7 x:"+x);
                        x++;
                        pesos[i, 0, numCO] = aux[x];
                    }
                    Pesos_W = pesos;
                    umbralesNeuronal = umbrales;

                 
                        numX = numIn;
                    numCapasOcultas = numCO;
                    numNeuro = numIn;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
            }  

        }
        public void guardarPesosEnArchivo(string rutaArchivo)
        {
            StreamWriter guardar = new StreamWriter(rutaArchivo);
            double aux;
            try
            {
                guardar.WriteLine(numX);
                guardar.WriteLine(numCapasOcultas);
                for (int k = 0; k < numCapasOcultas + 1; k++)
                {
                    if (k == numCapasOcultas)
                    {
                        aux = umbralesNeuronal[k][0];
                        guardar.WriteLine(aux.ToString());
                        Console.WriteLine(aux.ToString());
                        for (int i = 0; i < numX; i++)
                        {
                            guardar.WriteLine(Pesos_W[i, 0, k].ToString().Replace(',', '.'));
                            //Console.WriteLine(Pesos_W[i, 0, k].ToString());
                        }
                    }
                    else
                        for (int j = 0; j < numNeuro; j++)
                        {
                            aux = umbralesNeuronal[k][j];
                            guardar.WriteLine(aux.ToString().Replace(',', '.'));
                           // Console.WriteLine(aux.ToString());

                            for (int i = 0; i < numX; i++)
                            {
                                guardar.WriteLine(Pesos_W[i, j, k].ToString().Replace(',', '.'));
                               // Console.WriteLine(Pesos_W[i, j, k].ToString());
                            }
                        }
                }
                guardar.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("error :" + e.Message);
            }
        }        
        private double Sigmoidal(double x)//f1(x)
        {
            double aux = 0.0;
            try
            {
                aux = 1.0 / (1.0 + Math.Exp(-x));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return aux;
        }    
        public double funcionActivacion(){
            double suma = 0.0;
           
                //==CAPA ENTRADA===================================================================
                for (int i = 0; i < numX; i++)
                {//copiar elementos de la entrada
                    activacionNeuronal[0][i] = entradaX[i];

                }
                //Console.WriteLine("====CAPA OCULta=============================");

                for (int k = 0; k < numCapasOcultas; k++)
                {//indice numero de capasOcultas
                    for (int j = 0; j <  numNeuro ; j++) //2 indica numero de neuronas
                    {//indice de neurona j
                        suma = 0.0;
                        for (int i = 0; i < numX; i++)
                        {//indice de la conexion i
                            suma = suma + Pesos_W[i, j, k] * activacionNeuronal[k][i];
                            //            Console.WriteLine("P: "+Pesos_W[i,j,k]+";A: "+activacionNeuronal[k][i]);
                            //           Console.ReadKey();
                        }
                       activacionNeuronal[k + 1][j] = Sigmoidal(suma + umbralesNeuronal[k][j]); //se cayo por indice
                        }
                }

               // Console.WriteLine("===CAPA SALIDA======================================= ");          
                 

                suma = 0.0;
                for (int i = 0; i < numNeuro; i++)//indice de coneexion i
                {
                    suma = suma + Pesos_W[i, 0, numCapasOcultas] * activacionNeuronal[numCapasOcultas][i];
                    //    
                }
                //salidaY =TangenteHiperbolica(suma + umbralesNeuronal[numCapasOcultas][0]);
                activacionNeuronal[numCapasOcultas + 1][0] = Sigmoidal(suma + umbralesNeuronal[numCapasOcultas][0]); ;
              
                return activacionNeuronal[numCapasOcultas + 1][0];
          
        }       
        private double derivadaSigmoidal(double x)//f1(x)(1-f1(x))
        {
            double aux = 0;
            try
            {
                aux = Sigmoidal(x) * (1 - Sigmoidal(x));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return aux;
        }

        public void backPropagation(double s, double y)
        {
            try
            {
                double suma = 0;
                //  Console.WriteLine("//==BACK CAPA SALIDA==========================================");
                suma = 0;
                for (int i = 0; i < numNeuro; i++)
                {   //conexion neurona oculta j
                    suma = suma + Pesos_W[i, 0, numCapasOcultas] * activacionNeuronal[numCapasOcultas][i];
                }
               delta[numCapasOcultas, 0] = (s - y) * derivadaSigmoidal(suma + umbralesNeuronal[numCapasOcultas][0]);
                umbralesNeuronal[numCapasOcultas][0] = umbralesNeuronal[numCapasOcultas][0] + alfa * delta[numCapasOcultas, 0];
                //Console.WriteLine("//=======CAPA OCULTA==========================================");
                double sumaDelta;
                for (int k = numCapasOcultas - 1; k >= 0; k--)
                {//indice numero de capa oculta                 

                    for (int j = 0; j < numNeuro; j++)
                    {//indece neuro 
                        suma = 0;
                        sumaDelta = 0;
                        for (int i = 0; i < numNeuro; i++)
                        {
                            suma = suma + Pesos_W[i, j, k] * activacionNeuronal[k][i];
                        }
                        if (k < numCapasOcultas - 1)
                        {
                            for (int i = 0; i < numNeuro; i++)
                            { 
                                sumaDelta = Pesos_W[j, i, k + 1] * delta[k + 1, i];
                            }
                        }
                        else
                        {
                            sumaDelta = delta[numCapasOcultas, 0] * Pesos_W[j, 0, numCapasOcultas];
                            //   Console.WriteLine("sumD: "+sumaDelta);
                        }
                        //delta[k, j] = derivadaTangenteHiperbolica(suma + umbralesNeuronal[k][j]) * sumaDelta;
                        delta[k, j] = derivadaSigmoidal(suma + umbralesNeuronal[k][j]) * sumaDelta;
                        umbralesNeuronal[k][j] = umbralesNeuronal[k][j] + alfa * delta[k, j];
                    }
                }
                for (int i = 0; i < numNeuro; i++)
                {//bien
                    Pesos_W[i, 0, numCapasOcultas] = Pesos_W[i, 0, numCapasOcultas] + (alfa * activacionNeuronal[numCapasOcultas][i] * delta[numCapasOcultas, 0]);
                }
                for (int k = 0; k < numCapasOcultas; k++)
                    for (int j = 0; j < numNeuro; j++)
                        for (int i = 0; i < numNeuro; i++)//bien
                        {
                            Pesos_W[i, j, k] = Pesos_W[i, j, k] + (alfa * activacionNeuronal[k][i] * delta[k, j]);
                        }
            }catch(Exception ex){
                Console.WriteLine("Error en algoritmo de propagacion:"+ex.Message);
            }
        }
        public double errorMinimoCuadrado(double s, double y)
        {
            try {
                return Math.Pow(s - y,2)/2;
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                return 0;
            }                        
        }
        public double entrenamientoRed(double error,int iteraciones,List<double[]> patrones,int numentrada,int numPatrones,int posS){
            double errorRed=1;
            int iter = 0;
            entradaX = new double[numentrada];
            double e=1;
            int N =numPatrones;

            while(iter<iteraciones /*&& e>error*/){

                if (iter % 100 == 0)
                    Console.WriteLine(iter);

                e = 0;
                errorRed = 0;
                for(int j=0;j<N;j++){
                    for (int i = 0; i < numentrada; i++)
                    {
                        entradaX[i] = patrones[j][i];
                        //Console.WriteLine(entradaX[i]);
                    }
                   errorRed=errorMinimoCuadrado(patrones[j][posS], funcionActivacion());
                   backPropagation(patrones[j][posS],funcionActivacion());
                   e =+ errorRed;
                    //Console.WriteLine("e"+e);
                    //Console.WriteLine("errorRed:    "+errorRed);
                }
                e = e / N;
                iter++;
            }
            return e;
        }
        public void printDatos()
        {
            Console.WriteLine("nux: "+numX+" numCO "+numCapasOcultas);
            for (int k = 0; k < numCapasOcultas; k++)
            {
                for (int j = 0; j < numX; j++)                   
                        Console.WriteLine(umbralesNeuronal[k][j]);
                    
                
            }
            Console.WriteLine(umbralesNeuronal[umbralesNeuronal.Count-1][0]);
            Console.ReadLine();
          
            for (int k = 0; k < numCapasOcultas; k++)
            {
                Console.WriteLine("");
                for (int j = 0; j < numX; j++)
                {
                    for (int i = 0; i < numX; i++)
                    {
                        Console.WriteLine(Pesos_W[i, j, k]);
                    }
                }
            }
            for (int i = 0; i < numX; i++)
            {
                Console.WriteLine(Pesos_W[i, 0,numCapasOcultas]);
            }            
        }
        public List<double[]> cargarDatos(string ruta,int N)
        {
            List<double[]> listaPatrones = new List<double[]>();
            try
            {
                StreamReader lector = new StreamReader(ruta);
                string linea;
                linea = lector.ReadLine();                
                string[] caracteres;
                char[] delimitador = { ' ', ',' };
                double[] entradaAux;
                linea = lector.ReadLine();
                while (linea != null)
                {
         //           int pos = linea.IndexOf(' ');
       //             linea.Remove(pos+1);
                    caracteres = linea.Split(delimitador);
                    entradaAux = new double[caracteres.Count()-1];

                    try
                    {
                        int j = 0;
                        for (int i = 0; i < caracteres.Count(); i++)
                        {
                            if (caracteres[i] != "")
                            {
                                entradaAux[j] = Convert.ToDouble(caracteres[i].Replace('.', ','));
                                j++;
                            }                           
                            
                        }
                        listaPatrones.Add(entradaAux);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Patron erroneo :"+ex.Message);
                    }

                    linea = lector.ReadLine();
                }
            }
            catch (FileNotFoundException fe)
            {
                Console.WriteLine("Error :"+fe.Message);
            }
            return listaPatrones;
        }
      
      
    }

