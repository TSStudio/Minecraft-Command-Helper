﻿using System.Windows;
using System.Collections.Generic;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WpfMinecraftCommandHelper2
{
    /// <summary>
    /// Particle.xaml 的交互逻辑
    /// </summary>
    public partial class Particle : MetroWindow
    {
        public Particle()
        {
            InitializeComponent();
            appLanguage();
            AllSelData asd = new AllSelData();
            for (int i = 0; i < asd.getParticleStrCount(); i++)
            {
                tabParticleSel.Items.Add(asd.getParticleStrCn(i));
            }
            clear();
        }

        private string FloatHelpTitle = "帮助";
        private string FloatConfirm = "确认";
        private string FloatCancel = "取消";
        private string ParticleHelpStr = "";
        private string FloatErrorTitle = "错误";
        private string FloatHelpFileCantFind = "";

        private void appLanguage()
        {
            SetLang setlang = new SetLang();
            List<string> templang = setlang.SetParticle();
            try
            {
                FloatHelpTitle = templang[0];
                FloatConfirm = templang[1];
                FloatCancel = templang[2];
                tabParticleClear.Content = templang[3];
                tabParticleCreate.Content = templang[4];
                checkBtn.Content = templang[5];
                tabParticleCopy.Content = templang[6];
                tabParticleHelp.Content = templang[7];
                this.Title = templang[8];
                ParticleChooseEffect.Content = templang[9];
                tabParticleCN.Content = templang[10];
                tabParticleEN.Content = templang[11];
                ParticleXYZ.Content = templang[12];
                ParticleDxyz.Content = templang[13];
                ParticleSpeed.Content = templang[14];
                ParticleCount.Content = templang[15];
                tabParticleXNum.Content = templang[16];
                ParticleHelpStr = templang[17];
                FloatErrorTitle = templang[18];
                FloatHelpFileCantFind = templang[19];
            } catch (System.Exception) { /* throw; */ }
        }

        private string finalStr = "";
        private int particleSel = 0;

        private void clear() 
        {
            tabParticleX.Value = 0;
            tabParticleY.Value = 0;
            tabParticleZ.Value = 0;
            tabParticleEN.IsChecked = false;
            tabParticleCN.IsChecked = true;
            tabParticleSel.SelectedIndex = 0;
            tabParticleX.IsEnabled = false;
            tabParticleY.IsEnabled = false;
            tabParticleZ.IsEnabled = false;
            tabParticleXNum.IsChecked = true;
        }

        private void tabParticleCN_Checked(object sender, RoutedEventArgs e)
        {
            if (tabParticleCN.IsChecked.Value)
            {
                int index = tabParticleSel.SelectedIndex;
                AllSelData asd = new AllSelData();
                for (int i = 0; i < asd.getParticleStrCount(); i++)
                {
                    tabParticleSel.Items.RemoveAt(0);
                }
                for (int i = 0; i < asd.getParticleStrCount(); i++)
                {
                    tabParticleSel.Items.Add(asd.getParticleStrCn(i));
                }
                tabParticleSel.SelectedIndex = index;
            }
        }

        private void tabParticleEN_Checked(object sender, RoutedEventArgs e)
        {
            if (tabParticleEN.IsChecked.Value)
            {
                int index = tabParticleSel.SelectedIndex;
                AllSelData asd = new AllSelData();
                for (int i = 0; i < asd.getParticleStrCount(); i++)
                {
                    tabParticleSel.Items.RemoveAt(0);
                }
                for (int i = 0; i < asd.getParticleStrCount(); i++)
                {
                    tabParticleSel.Items.Add(asd.getParticleStrEn(i));
                }
                tabParticleSel.SelectedIndex = index;
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clear();
            tabParticleCN.IsChecked = true;
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            int langIndex = tabParticleSel.SelectedIndex;
            particleSel = tabParticleSel.SelectedIndex;
            string particleOut = "/particle ";
            //particle
            AllSelData asd = new AllSelData();
            if (langIndex == 0)
            {
                //tabParticleBox.Text = "请选择效果类型！";
            }
            else if (langIndex == 1)
            {
                particleOut = particleOut + asd.getParticle(langIndex) + "_" + tabParticleID.Value + "_" + tabParticleMeta.Value + " ";
            }
            else if (langIndex == 2)
            {
                particleOut = particleOut + asd.getParticle(langIndex) + "_" + tabParticleID.Value + " ";
            }
            else if (langIndex == 3)
            {
                particleOut = particleOut + asd.getParticle(langIndex) + "_" + tabParticleID.Value + " ";
            }
            else
            {
                particleOut = particleOut + asd.getParticle(langIndex) + " ";
            }
            //local
            if (tabParticleXNum.IsChecked == true)
            {
                particleOut = particleOut + "~ ~ ~ ";
            }
            else
            {
                particleOut = particleOut + tabParticleX.Value + " " + tabParticleY.Value + " " + tabParticleZ.Value + " ";
            }
            //dyn
            particleOut = particleOut + tabParticleDx.Value + " " + tabParticleDy.Value + " " + tabParticleDz.Value + " ";
            //speed
            particleOut = particleOut + tabParticleSpeed.Value + " " + tabParticleCount.Value;
            finalStr = particleOut;
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.UnicodeText, finalStr);
        }

        private void checkBtn_Click(object sender, RoutedEventArgs e)
        {
            Check checkbox = new Check();
            checkbox.showText(finalStr);
            checkbox.Show();
        }

        public int returnParticleSel() { return particleSel; } 

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.ShowMessageAsync(FloatHelpTitle, ParticleHelpStr, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
        }

        private void tabParticleXNum_Checked(object sender, RoutedEventArgs e)
        {
            if (tabParticleXNum.IsChecked.Value)
            {
                tabParticleX.IsEnabled = false;
                tabParticleY.IsEnabled = false;
                tabParticleZ.IsEnabled = false;
            }
            else
            {
                tabParticleX.IsEnabled = true;
                tabParticleY.IsEnabled = true;
                tabParticleZ.IsEnabled = true;
            }
        }

        private void MetroWindow_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\Help\Particle.html";
            if (e.Key == System.Windows.Input.Key.F1)
            {
                if (System.IO.File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    this.ShowMessageAsync(FloatErrorTitle, FloatHelpFileCantFind, MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = FloatConfirm, NegativeButtonText = FloatCancel });
                }
            }
        }
    }
}
