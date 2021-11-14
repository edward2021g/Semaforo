using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semaforo
{
    public partial class Form1 : Form
    {
        //int int_caso = 0;
        int int_numero = 0;
        private int int_ticks = 1;
        private int int_tick_preventivas;
        private int int_tick_verde_parpadeante = 1;
        private int int_tick_amarillo = 1;
        private int int_tick_rojo = 1;
        bool bln_primer_ciclo = true;

        const double TIMEOUT = 5000; // milliseconds

        //
        //

        //varable para pausar y reanudar el timer correcto
        string timer_actual = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pct_semaforo1.Image = Semaforo.Properties.Resources.apagado;
            pct_semaforo2.Image = Semaforo.Properties.Resources.apagado;
            pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
            pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;
            btn_apagar.Enabled = false;
            btn_parar.Enabled = false;
            lbl_contador.ForeColor = Color.Black;

            //giro los semaforos laterales 90 grados
            pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
            pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            MoverVehiculo();

            btn_iniciar.Enabled = false;
            btn_parar.Enabled = true;
            btn_apagar.Enabled = true;

            pct_semaforo3.Image = Semaforo.Properties.Resources.rojo;
            pct_semaforo4.Image = Semaforo.Properties.Resources.rojo;

            //giro los semaforos laterales 90 grados
            pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);

            // Descripcion de los pasos secuenciales:

            // Paso 1: Contar hasta 10 segundos y medio con verde estatico y se apaga el 10 medio segundo.

            lbl_contador.ForeColor = Color.Green; //empieza en verde
            lbl_contador.Text = "1";

            pct_semaforo1.Image = Semaforo.Properties.Resources.verde;
            pct_semaforo2.Image = Semaforo.Properties.Resources.verde;
            pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
            timer1.Start();
            //bln_primer_ciclo = false;

            // Paso 2: prender el 1, apagar el 1, 2 y 3 (verde parpadeante)
            // paso 3: Prender el amarillo por 2.5 segundos. POner 1, apagarlo, 2 y apagrlo, 3 y aparglo segundos apagarlo
            // paso 4: Contar 2 segundos con el rojo, apagrlo y empezar el ciclo con los otros contadores


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            int_numero =  (int_ticks / 2) +1 ;
            lbl_contador.Text = int_numero.ToString(); //muestra los segundos

            ++int_ticks; //cuenta cada medio segundo 2 ticks = 1 seg
            this.Text = int_ticks.ToString(); //muestra los ticks
            */

            if(bln_primer_ciclo == true)
            {
                if (int_ticks == 0)
                {
                    int_ticks = 1;
                }

                int_numero = (int_ticks / 2) + 1;
                lbl_contador.Text = int_numero.ToString(); //muestra los segundos

                ++int_ticks; //cuenta cada medio segundo 2 ticks = 1 seg
                this.Text = int_ticks.ToString(); //muestra los ticks

                // ----------- apaga y prende por 3 segundos y medio en verde --
                if (int_ticks == 20) //en 9.5 seg
                {
                    pct_semaforo1.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                    lbl_contador.ForeColor = Color.Gray;
                    int_numero = 0;
                    timer1.Stop();
                    int_ticks = 0;
                    timer_verde_parpadeante.Start();
                }
            }
            else
            {
                if (int_ticks == 0)
                {
                    int_ticks = 1;
                }

                int_numero = (int_ticks / 2) + 1;
                lbl_contador.Text = int_numero.ToString(); //muestra los segundos

                ++int_ticks; //cuenta cada medio segundo 2 ticks = 1 seg
                this.Text = int_ticks.ToString(); //muestra los ticks

                // ----------- apaga y prende por 3 segundos y medio en verde --
                if (int_ticks == 20) //en 9.5 seg
                {
                    pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;
                    //giro los semaforos laterales 90 grados
                    pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    //pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                    lbl_contador.ForeColor = Color.Gray;
                    int_numero = 0;
                    timer1.Stop();
                    int_ticks = 0;
                    timer_verde_parpadeante.Start();
                }
            }

        }

        private void btn_parar_Click(object sender, EventArgs e)
        {
            
            if (btn_parar.Text == "PARAR")
            {
                if (timer1.Enabled == true)
                {
                    timer1.Enabled = false;
                    timer_actual = "timer1";
                }
                if (timer_verde_parpadeante.Enabled == true)
                {
                    timer_verde_parpadeante.Enabled = false;
                    timer_actual = "timer_verde_parpadeante";
                }
                if (timer_amarillo.Enabled == true)
                {
                    timer_amarillo.Enabled = false;
                    timer_actual = "timer_amarillo";
                }
                if (timer_rojo.Enabled == true)
                {
                    timer_rojo.Enabled = false;
                    timer_actual = "timer_rojo";
                }
                btn_parar.Text = "REANUDAR";
                pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
            }
            else
            {
               if (btn_parar.Text == "REANUDAR")
                {
                    switch (timer_actual)
                    {
                        case "timer1":timer1.Enabled = true;
                            break;
                        case "timer_verde_parpadeante": timer_verde_parpadeante.Enabled = true;
                            break;
                        case "timer_amarillo":timer_amarillo.Enabled = true;
                            break;
                        case "timer_rojo":
                            timer_rojo.Enabled = true;
                            break;
                    }
                    
                    btn_parar.Text = "PARAR";
                    pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                }
            }
        }

        private void btn_apagar_Click(object sender, EventArgs e)
        {
            
            btn_parar.Enabled = false;
            btn_apagar.Enabled = false;
            btn_iniciar.Enabled = true;
            btn_Preventivas.Enabled = true;

            //int_ticks = 0;
            //int_numero = 0;
            lbl_contador.Text = "0";
            lbl_contador.ForeColor = Color.Black;
            btn_parar.Text = "PARAR";

            //reinicio las variables
            int_tick_verde_parpadeante = 1;
            int_ticks = 1;
            int_tick_amarillo = 1;
            int_tick_rojo = 1;
            bln_primer_ciclo = true;

            //detengo los timers
            timer1.Stop();
            timer_preventivas.Stop();
            timer_verde_parpadeante.Stop();
            timer_amarillo.Stop();
            timer_rojo.Stop();


            pct_semaforo1.Image = Semaforo.Properties.Resources.apagado;
            pct_semaforo2.Image = Semaforo.Properties.Resources.apagado;
            pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
            pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;

            //giro los semaforos laterales 90 grados
            pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
            pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
        }

        private void btn_Preventivas_Click(object sender, EventArgs e)
        {
            //detengo los timers
            timer1.Stop();
            timer_verde_parpadeante.Stop();
            timer_amarillo.Stop();

            //reinicio las variables
            int_tick_verde_parpadeante = 1;
            int_ticks = 1;
            int_tick_amarillo = 1;

            btn_parar.Enabled = false;
            btn_apagar.Enabled = true;
            btn_iniciar.Enabled = false;
            //int_ticks = 0;
            //int_numero = 0;
            lbl_contador.Text = "0";
            lbl_contador.ForeColor = Color.Gray;
            btn_parar.Text = "PARAR";
            timer_preventivas.Start();

            //Comentado 10/nov/2021
            /*
            pct_semaforo1.Image = Semaforo.Properties.Resources.amarillo;
            pct_semaforo2.Image = Semaforo.Properties.Resources.amarillo;
            pct_semaforo3.Image = Semaforo.Properties.Resources.amarillo;
            pct_semaforo4.Image = Semaforo.Properties.Resources.amarillo;
            //giro los semaforos laterales 90 grados
            pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
            pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
            */
        }

        private void timer_preventivas_Tick(object sender, EventArgs e)
        {
            if(int_tick_preventivas == 0)
            {
                int_tick_preventivas = 1;
            }

            int_tick_preventivas++; //cuenta cada medio segundo 2 ticks = 1 seg

            if (int_tick_preventivas % 2 == 0)
            {
                //lbl_contador.ForeColor = Color.Gold;
                //lbl_contador.ForeColor = Color.LightYellow;
                lbl_contador.ForeColor = Color.FromArgb(255, 219, 43); //amarillo
                pct_semaforo1.Image = Semaforo.Properties.Resources.amarillo;
                pct_semaforo2.Image = Semaforo.Properties.Resources.amarillo;
                pct_semaforo3.Image = Semaforo.Properties.Resources.amarillo;
                pct_semaforo4.Image = Semaforo.Properties.Resources.amarillo;
                OrientarTodosSemaforos();
            }
            else
            {
                lbl_contador.ForeColor = Color.Gray;
                pct_semaforo1.Image = Semaforo.Properties.Resources.apagado;
                pct_semaforo2.Image = Semaforo.Properties.Resources.apagado;
                pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
                pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;
                OrientarTodosSemaforos();
            }
        }

        private void OrientarTodosSemaforos()
        {
            //giro los semaforos laterales 90 grados
            pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
            pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
        }
        private void timer_verde_parpadeante_Tick(object sender, EventArgs e)
        {
            int_tick_verde_parpadeante++; //cuenta cada segundo 2 ticks = 1 seg

            if (int_tick_verde_parpadeante == 1) //se muestra el 3 apagado
            {
                lbl_contador.Text = "1";
            }
            else
            {
                lbl_contador.Text = ((int_tick_verde_parpadeante / 2)).ToString(); //muestra los segundos
            }

            if (bln_primer_ciclo == true)
            {
                if (int_tick_verde_parpadeante % 2 != 0)
                {
                    lbl_contador.ForeColor = Color.Gray;
                    pct_semaforo1.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                }
                else
                {
                    lbl_contador.ForeColor = Color.Green;
                    pct_semaforo1.Image = Semaforo.Properties.Resources.verde;
                    pct_semaforo2.Image = Semaforo.Properties.Resources.verde;
                    pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                }

                if (int_tick_verde_parpadeante == 7) //se muestra el 3 apagado
                {
                    timer_verde_parpadeante.Stop();
                    int_tick_verde_parpadeante = 1;
                    timer_amarillo.Start();
                }
            }
            else
            {
                if (int_tick_verde_parpadeante % 2 != 0)
                {
                    lbl_contador.ForeColor = Color.Gray;
                    pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;
                    //giro los semaforos laterales 90 grados
                    pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    //pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                }
                else
                {
                    lbl_contador.ForeColor = Color.Green;
                    pct_semaforo3.Image = Semaforo.Properties.Resources.verde;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.verde;
                    //giro los semaforos laterales 90 grados
                    pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    //pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                }

                if (int_tick_verde_parpadeante == 7) //se muestra el 3 apagado
                {
                    timer_verde_parpadeante.Stop();
                    int_tick_verde_parpadeante = 1;
                    timer_amarillo.Start();
                }
            }

        }

        private void timer_amarillo_Tick(object sender, EventArgs e)
        {
            int_tick_amarillo++; //cuenta cada segundo 2 ticks = 1 seg

            if (int_tick_amarillo == 1) //se muestra el 3 apagado
            {
                lbl_contador.Text = "1";
            }
            else
            {
                lbl_contador.Text = ((int_tick_amarillo / 2)).ToString(); //muestra los segundos
            }

            lbl_contador.ForeColor = Color.FromArgb(255, 219, 43);

            if (bln_primer_ciclo == true)
            {
                pct_semaforo1.Image = Semaforo.Properties.Resources.amarillo;
                pct_semaforo2.Image = Semaforo.Properties.Resources.amarillo;
                pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados

                if (int_tick_amarillo == 7) //se muestra el 3 apagado
                {
                    lbl_contador.ForeColor = Color.Gray;
                    pct_semaforo1.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                    timer_amarillo.Stop();

                    int_tick_amarillo = 1;
                    timer_rojo.Start();
                }
            }
            else
            {
                pct_semaforo3.Image = Semaforo.Properties.Resources.amarillo;
                pct_semaforo4.Image = Semaforo.Properties.Resources.amarillo;
                //giro los semaforos laterales 90 grados
                pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                //pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados

                if (int_tick_amarillo == 7) //se muestra el 3 apagado
                {
                    lbl_contador.ForeColor = Color.Gray;
                    pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;
                    //giro los semaforos laterales 90 grados
                    pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    //pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                    timer_amarillo.Stop();

                    int_tick_amarillo = 1;
                    timer_rojo.Start();
                }
            }
            
        }

        private void timer_rojo_Tick(object sender, EventArgs e)
        {
            int_tick_rojo++; //cuenta cada segundo 2 ticks = 1 seg

            if (int_tick_rojo == 1) //se muestra el 3 apagado
            {
                lbl_contador.Text = "1";
            }
            else
            {
                lbl_contador.Text = ((int_tick_rojo / 2)).ToString(); //muestra los segundos
            }

            lbl_contador.ForeColor = Color.Red;

            if (bln_primer_ciclo == true)
            {
                pct_semaforo1.Image = Semaforo.Properties.Resources.rojo;
                pct_semaforo2.Image = Semaforo.Properties.Resources.rojo;
                pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados

                //Actualizacion 10/nov/2021
                if(int_tick_rojo == 5)
                {
                    lbl_contador.ForeColor = Color.Gray;
                    pct_semaforo1.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                }
                //10/nov/2021

                //if (int_tick_rojo == 5) //se muestra el 3 apagado
                if (int_tick_rojo == 6)
                {
                    //comentado 10/nov/2021
                    /*
                    lbl_contador.ForeColor = Color.Gray;
                    pct_semaforo1.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                    */

                    int_tick_rojo = 1;
                    timer_rojo.Stop();

                    //if (bln_primer_ciclo == true)
                    //{
                        bln_primer_ciclo = false;

                        timer1.Start();
                        lbl_contador.Text = "1";
                        lbl_contador.ForeColor = Color.Green;

                        //cambiar a los semaforos 3 y 4 a verde y pongo en rojo los 1y 2
                        pct_semaforo3.Image = Semaforo.Properties.Resources.verde;
                        pct_semaforo4.Image = Semaforo.Properties.Resources.verde;
                        //giro los semaforos laterales 90 grados
                        pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                        pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                        pct_semaforo1.Image = Semaforo.Properties.Resources.rojo;
                        pct_semaforo2.Image = Semaforo.Properties.Resources.rojo;
                        pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                    //}
                    //else
                    //{
                        /*
                        bln_primer_ciclo = true;

                        timer1.Start();
                        lbl_contador.Text = "1";
                        lbl_contador.ForeColor = Color.Green;

                        //cambiar a los semaforos 3 y 4 a verde y pongo en rojo los 1y 2
                        pct_semaforo3.Image = Semaforo.Properties.Resources.rojo;
                        pct_semaforo4.Image = Semaforo.Properties.Resources.rojo;
                        //giro los semaforos laterales 90 grados
                        pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                        pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                        pct_semaforo1.Image = Semaforo.Properties.Resources.verde;
                        pct_semaforo2.Image = Semaforo.Properties.Resources.verde;
                        pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                        */
                    //}
                }
            }
            else
            {
                pct_semaforo3.Image = Semaforo.Properties.Resources.rojo;
                pct_semaforo4.Image = Semaforo.Properties.Resources.rojo;
                //giro los semaforos laterales 90 grados
                pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                //pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados

                //Actualizacion 10/nov/2021
                if (int_tick_rojo == 5)
                {
                    lbl_contador.ForeColor = Color.Gray;
                    pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;
                    //giro los semaforos laterales 90 grados
                    pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    //pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                }
                //10/nov/2021

                if (int_tick_rojo == 6)
                {
                    //comentado 10/nov/2021
                    /*
                    lbl_contador.ForeColor = Color.Gray;
                    pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;
                    */
                    //giro los semaforos laterales 90 grados
                    pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    //pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados

                    int_tick_rojo = 1;
                    timer_rojo.Stop();

                    bln_primer_ciclo = true;

                    //int_ticks = 1;
                    timer1.Start();
                    lbl_contador.Text = "1";
                    lbl_contador.ForeColor = Color.Green;
                    

                    //cambiar a los semaforos 3 y 4 a verde y pongo en rojo los 1y 2
                    pct_semaforo3.Image = Semaforo.Properties.Resources.rojo;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.rojo;
                    //giro los semaforos laterales 90 grados
                    pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
                    pct_semaforo1.Image = Semaforo.Properties.Resources.verde;
                    pct_semaforo2.Image = Semaforo.Properties.Resources.verde;
                    pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                }
            }
            

            


        }

        // Movimiento del vehiculo1
        private void MoverVehiculo()
        {
            System.Timers.Timer miTimer = new System.Timers.Timer();
            miTimer.Elapsed += new System.Timers.ElapsedEventHandler(eventoTimerVehiculo1);
            miTimer.Interval = 100;
            miTimer.Enabled = true;
            GC.KeepAlive(miTimer);
        }
        private void Vehiculo1(int x, int y)
        {
            pct_vehiculo1.Top = y - 10;
            /*
            if (y < this.Height - pct_vehiculo1.Height)
            {
                pct_vehiculo1.Top = y - 10;
            }*/
        }

        private void eventoTimerVehiculo1(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Vehiculo1(pct_vehiculo1.Left, pct_vehiculo1.Top);
        }
        //-------
        /*
        private void btn_mover_Click(object sender, EventArgs e)
        {
            System.Timers.Timer miTimer = new System.Timers.Timer();
            miTimer.Elapsed += new System.Timers.ElapsedEventHandler(eventoTimer);
            miTimer.Interval = 100;
            miTimer.Enabled = true;
            GC.KeepAlive(miTimer);
        }*/
        
        private void eventoTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            //CheckForIllegalCrossThreadCalls = false;
            //moveImage(pct_vehiculo1.Left, pct_vehiculo1.Top);
            //pct_vehiculo1.Top = (pct_vehiculo1.Top) - 10;
            pct_vehiculo1.Top -= 10;
        }

        private void moveImage(int x, int y)
        {
            /*
            if (y < this.Height - pct_vehiculo1.Height)
            {
                //pct_vehiculo1.Left = x + 20;
                pct_vehiculo1.Top = y - 10;
            }
            */
            /*
            else if (x < this.Width - pct_vehiculo1.Width)
            {
                pct_vehiculo1.Left = x + 20;
            }*/
        }
    }
}
