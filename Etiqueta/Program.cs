using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;

using System.Text;

namespace Etiqueta
{

    class tag
    {
        Queue miCola ;
        Stack miPila  ;
        int tamC = 0;
        int tamP = 0;
        public void extraer()
        {
            StreamReader arc = new StreamReader("tag.txt");
            string linea = "";

            miCola = new Queue() ;
            miPila = new Stack() ;
            int tam = 0;
            
             

            while ((linea = arc.ReadLine()) != null )
            {
                tam = linea.Length;
                
                for(int i=0; i<tam; i++)
                {
                    if ((int)linea[i] ==60 && (int)linea[i + 2] ==62 && (i + 2) < tam)
                    {
                        if ((int)linea[i + 1] >= 65 && (int)linea[i + 1] <= 90)
                        {
                            
                            miCola.Enqueue( linea[i + 1]);
                            tamC++;
                           
                        }
                    }
                    
                        if ((int)linea[i] ==60 && (int)linea[i + 1] ==47 && (int)linea[i + 3] ==62 && (i + 1) < tam && (i + 3) < tam)
                        {
                            
                            if ((int)linea[i + 2] >= 65 && (int)linea[i + 2] <= 90)
                            {
                                miPila.Push(linea[i + 2]);
                                tamP++;
                                
                            }
                        }
                }
                if (linea[tam - 1] == '#')
                { recorrer(); 
                }


            } arc.Close();
            Console.Read();
            
           
        }
        public void recorrer()
        {
            ArrayList objCola = new ArrayList();
            ArrayList objPila = new ArrayList();


            foreach (Object variableC in miCola)
              objCola.Add(variableC.ToString());
                

            foreach (object variableP in miPila)
                objPila.Add(variableP.ToString());

           
            //////////COMPROBAR

            if (tamC == tamP && tamC > 0)
            {
                int ban = 0;

                for (int i = tamC - 1; i >= 0 && ban == 0; i--)
                {
                    if (objPila[i].Equals(objCola[i]) == true)
                        ban = 0;
                    if (objPila[i].Equals(objCola[i]) == false)
                        ban = i;


                }
                if (ban == 0)
                    Console.WriteLine("Correctly tagged paragraph");
                else
                    Console.WriteLine("Expected </" + objCola[ban] + "> found </" + objPila[ban] + ">");
            }
            if (tamC > tamP && (tamC-tamP)==1)
            {

                Console.WriteLine("Expected </"+objCola[0]+"> found #");
            }
            if (tamC< tamP )
            {

                Console.WriteLine("Expected # found </" + objPila[0] );
            }


                Console.Read();

                tamC = 0;
                tamP = 0;
                miCola.Clear();
                miPila.Clear();
        
        }
    
    }
   
    class Program
    {

        
        static void Main(string[] args)
        {
            tag etiq = new tag();
            etiq.extraer();
         
        }
    }
}
