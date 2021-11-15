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
        int int_numero = 0;
        private int int_ticks = 1;
        private int int_tick_preventivas;
        private int int_tick_verde_parpadeante = 1;
        private int int_tick_amarillo = 1;
        private int int_tick_rojo = 1;
        bool bln_primer_ciclo = true;

        //ticks de los vehiculos
        private int int_ticks_v1 = 0;
        private int int_ticks_v2 = 0;

        //varable para pausar y reanudar el timer correcto
        string timer_actual = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ApagarTodosSemaforos();
            btn_apagar.Enabled = false;
            btn_parar.Enabled = false;
            OrientarTodosSemaforos();
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            btn_iniciar.Enabled = false;
            btn_parar.Enabled = true;
            btn_apagar.Enabled = true;

            pct_semaforo3.Image = Semaforo.Properties.Resources.rojo;
            pct_semaforo4.Image = Semaforo.Properties.Resources.rojo;
            pct_semaforo1.Image = Semaforo.Properties.Resources.verde;
            pct_semaforo2.Image = Semaforo.Properties.Resources.verde;
            OrientarTodosSemaforos();

            lbl_contador.ForeColor = Color.Green; //empieza en verde
            lbl_contador.Text = "1";
            timer_verde.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(bln_primer_ciclo == true)
            { 
                if (int_ticks == 0){int_ticks = 1;}
                if (int_ticks == 1){ MoverVehiculo(1);}
                int_numero = (int_ticks / 2) + 1;
                lbl_contador.Text = int_numero.ToString(); //muestra los segundos
                ++int_ticks; //cuenta cada medio segundo 2 ticks = 1 seg
                if (int_ticks == 20)
                {
                    pct_semaforo1.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                    lbl_contador.ForeColor = Color.Gray;
                    int_numero = 0;
                    timer_verde.Stop();
                    int_ticks = 0;
                    timer_verde_parpadeante.Start();
                    MoverVehiculo(1);
                }
            }
            else
            {
                if (int_ticks == 0){ int_ticks = 1;}
                if (int_ticks == 1){ MoverVehiculo(2);}
                int_numero = (int_ticks / 2) + 1;
                lbl_contador.Text = int_numero.ToString(); //muestra los segundos
                ++int_ticks; //cuenta cada medio segundo 2 ticks = 1 seg
                if (int_ticks == 20)
                {
                    pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;
                    OreintarSemaforosLaterales();
                    lbl_contador.ForeColor = Color.Gray;
                    int_numero = 0;
                    timer_verde.Stop();
                    int_ticks = 0;
                    timer_verde_parpadeante.Start();
                }
            }
        }

        private void btn_parar_Click(object sender, EventArgs e)
        {
            if (btn_parar.Text == "PARAR")
            {
                if (timer_verde.Enabled == true)
                {
                    timer_verde.Enabled = false;
                    timer_actual = "timer_verde";
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
                if (bln_primer_ciclo == true)//timers de los vehiculos
                {
                    timer_v1.Enabled = false;
                }
                else
                {
                    timer_v2.Enabled = false;
                }
                btn_parar.Text = "REANUDAR";
            }
            else
            {
               if (btn_parar.Text == "REANUDAR")
                {
                    switch (timer_actual)
                    {
                        case "timer_verde":timer_verde.Enabled = true;
                            break;
                        case "timer_verde_parpadeante": timer_verde_parpadeante.Enabled = true;
                            break;
                        case "timer_amarillo":timer_amarillo.Enabled = true;
                            break;
                        case "timer_rojo":
                            timer_rojo.Enabled = true;
                            break;
                    }
                    if(bln_primer_ciclo == true)//timers de los vehiculos
                    {
                        timer_v1.Enabled = true;
                    }
                    else
                    {
                        timer_v2.Enabled = true;
                    }
                    btn_parar.Text = "PARAR";
                }
            }
        }

        private void btn_apagar_Click(object sender, EventArgs e)
        {
            btn_parar.Enabled = false;
            btn_apagar.Enabled = false;
            btn_iniciar.Enabled = true;
            btn_Preventivas.Enabled = true;
            lbl_contador.Text = "0";
            lbl_contador.ForeColor = Color.Gray;
            btn_parar.Text = "PARAR";
            bln_primer_ciclo = true;
            ReinicarVariables();
            DetenerTimers();
            ApagarTodosSemaforos();
            OrientarTodosSemaforos();
            pct_vehiculo1.Location = new System.Drawing.Point(594, 575); //coloco los vehiculos en su posicion de inicio
            pct_vehiculo2.Location = new System.Drawing.Point(-87, 313);
        }

        private void btn_Preventivas_Click(object sender, EventArgs e)
        {
            DetenerTimers();
            ReinicarVariables();
            btn_parar.Enabled = false;
            btn_apagar.Enabled = true;
            btn_iniciar.Enabled = false;
            lbl_contador.Text = "0";
            lbl_contador.ForeColor = Color.Gray;
            btn_parar.Text = "PARAR";
            timer_preventivas.Start();
            pct_vehiculo1.Location = new System.Drawing.Point(594, 575); //coloco los vehiculos en su posicion de inicio
            pct_vehiculo2.Location = new System.Drawing.Point(-87, 313);
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
                ApagarTodosSemaforos();
                OrientarTodosSemaforos();
            }
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
                    OreintarSemaforosLaterales();
                }
                else
                {
                    lbl_contador.ForeColor = Color.Green;
                    pct_semaforo3.Image = Semaforo.Properties.Resources.verde;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.verde;
                    OreintarSemaforosLaterales();
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
            if (int_tick_amarillo == 1) 
            { lbl_contador.Text = "1";}
            else { lbl_contador.Text = ((int_tick_amarillo / 2)).ToString(); } //muestra los segundos

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
                OreintarSemaforosLaterales();
                if (int_tick_amarillo == 7) //se muestra el 3 apagado
                {
                    lbl_contador.ForeColor = Color.Gray;
                    pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;
                    OreintarSemaforosLaterales();
                    timer_amarillo.Stop();
                    int_tick_amarillo = 1;
                    timer_rojo.Start();
                }
            }
        }

        private void timer_rojo_Tick(object sender, EventArgs e)
        {
            int_tick_rojo++; //cuenta cada segundo 2 ticks = 1 seg

            if (int_tick_rojo == 1) 
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

                if(int_tick_rojo == 5)
                {
                    lbl_contador.ForeColor = Color.Gray;
                    pct_semaforo1.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
                }
                
                if (int_tick_rojo == 6) //se muestra el 2 apagado
                {
                    int_tick_rojo = 1;
                    timer_rojo.Stop();
                    bln_primer_ciclo = false;
                    timer_verde.Start();
                    lbl_contador.Text = "1";
                    lbl_contador.ForeColor = Color.Green;

                    //cambiar a los semaforos 3 y 4 a verde y pongo en rojo los 1y 2
                    pct_semaforo3.Image = Semaforo.Properties.Resources.verde;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.verde;
                    pct_semaforo1.Image = Semaforo.Properties.Resources.rojo;
                    pct_semaforo2.Image = Semaforo.Properties.Resources.rojo;
                    OrientarTodosSemaforos();
                }
            }
            else
            {
                pct_semaforo3.Image = Semaforo.Properties.Resources.rojo;
                pct_semaforo4.Image = Semaforo.Properties.Resources.rojo;
                OreintarSemaforosLaterales();

                //Actualizacion 10/nov/2021
                if (int_tick_rojo == 5)
                {
                    lbl_contador.ForeColor = Color.Gray;
                    pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;
                    OreintarSemaforosLaterales();
                }
                //10/nov/2021

                if (int_tick_rojo == 6)
                {
                    int_tick_rojo = 1;
                    timer_rojo.Stop();
                    bln_primer_ciclo = true;
                    timer_verde.Start();
                    lbl_contador.Text = "1";
                    lbl_contador.ForeColor = Color.Green;

                    //cambiar a los semaforos 3 y 4 a verde y pongo en rojo los 1y 2
                    pct_semaforo3.Image = Semaforo.Properties.Resources.rojo;
                    pct_semaforo4.Image = Semaforo.Properties.Resources.rojo;
                    pct_semaforo1.Image = Semaforo.Properties.Resources.verde;
                    pct_semaforo2.Image = Semaforo.Properties.Resources.verde;
                    OrientarTodosSemaforos();
                }
            }
        }

        //segunda version del metodo para mover el vehiculo
        private void MoverVehiculo(int numero)
        {
            if(numero == 1)
            {
                pct_vehiculo1.Location = new System.Drawing.Point(594, 575);
                timer_v1.Start();
            }
            if (numero == 2)
            {
                pct_vehiculo2.Location = new System.Drawing.Point(-87, 313);
                timer_v2.Start();
            }
        }

        private void timer_v1_Tick(object sender, EventArgs e)
        {
            int_ticks_v1++;
            pct_vehiculo1.Top = pct_vehiculo1.Top - 10;
        }

        private void timer_v2_Tick(object sender, EventArgs e)
        {
            int_ticks_v2++;
            pct_vehiculo2.Left = pct_vehiculo2.Left + 10;
        }

        private void OrientarTodosSemaforos()
        {
            //giro los semaforos laterales 90 grados
            pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
            pct_semaforo2.Image.RotateFlip(RotateFlipType.Rotate180FlipX); //gira el semaforo 2 a 180 grados
        }

        private void ApagarTodosSemaforos()
        {
            pct_semaforo1.Image = Semaforo.Properties.Resources.apagado;
            pct_semaforo2.Image = Semaforo.Properties.Resources.apagado;
            pct_semaforo3.Image = Semaforo.Properties.Resources.apagado;
            pct_semaforo4.Image = Semaforo.Properties.Resources.apagado;
        }

        private void OreintarSemaforosLaterales()
        {
            //giro los semaforos laterales 90 grados
            pct_semaforo3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
            pct_semaforo4.Image.RotateFlip(RotateFlipType.Rotate90FlipX);
        }
        private void DetenerTimers()
        {
            //detengo los timers
            timer_verde.Stop();
            timer_preventivas.Stop();
            timer_verde_parpadeante.Stop();
            timer_amarillo.Stop();
            timer_rojo.Stop();
            timer_v1.Stop();
            timer_v2.Stop();
        }

        private void ReinicarVariables()
        {
            int_tick_verde_parpadeante = 1;
            int_ticks = 1;
            int_tick_amarillo = 1;
            int_tick_rojo = 1;
            int_ticks_v1 = 0;
            int_ticks_v2 = 0;
            timer_actual = "";
            int_tick_preventivas = 0;
        }
    }
}
