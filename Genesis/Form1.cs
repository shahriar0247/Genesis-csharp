using System;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.IO;
using System.Diagnostics;

namespace Genesis
{
    public partial class Genesis : Form
    {

        SpeechSynthesizer s = new SpeechSynthesizer();
        Choices list = new Choices();

        public Genesis()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            //Necessary commands

            list.Add(new String[] {"hello", "how are you", "who are you", "what time is it",
                "what day is it", "open bing", "open google", "open youtube","open this pc", "open computer", "open my computer",
            "open document", "open my document", "open documents", "open my documents",
                "open download", "open my download",  "open downloads", "open my downloads",
            "open notepad","open note pad" , "open word", "open command prompt", "open google chrome", "open chrome", "open firefox",
            "open mozilla firefox", "open excel", "open cmd", "quit", "exit", "show help", "show all commands", "show commands",
            "hide commands", "hide all commands", "hide help" });

            Grammar gr = new Grammar(new GrammarBuilder(list));

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }
            s.SelectVoiceByHints(VoiceGender.Female);
            s.Speak("Starting Genesis");
            InitializeComponent();
        }

        public void say(String h)
        {
            s.Speak(h);
        }

        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;

            // all ifs and elses

         
           
                if (r == "hello")
                {
                    say("hi");
                }

                if (r == "how are you")
                {
                    say("i m great, how about you");
                }

                if (r == "who are you")
                {
                    say("Hello i am genesis and i am created by ahmed shah rear");
                }

                if (r == "what time is it")
                {
                    say(DateTime.Now.ToString("h:mm tt"));
                }

                if (r == "what day is it")
                {
                    say(DateTime.Now.ToString("M/d/yyyy"));
                }

                if (r == "open google")
                {
                    Process.Start("http://www.google.com");

                }

                if (r == "open bing")
                {
                    Process.Start("http://www.bing.com");

                }
                if (r == "open youtube")
                {
                    Process.Start("http://www.youtube.com");

                }

                if (r == "open this pc" || r == "open computer" || r == "open my computer")
                {
                    Process.Start("::{20d04fe0-3aea-1069-a2d8-08002b30309d}");
                }

                if (r == "open documents" || r == "open my documents" || r == "open document" || r == "open my document")
                {
                    Process.Start("::{450d8fba-ad25-11d0-98a8-0800361b1103}");
                }

                if (r == "open download" || r == "open my download" || r == "open downloads" || r == "open my downloads")
                {
                    Process.Start("shell:Downloads");
                }
                if (r == "open notepad" || r == "open note pad")
                {
                    Process.Start(@"C:\Windows\notepad.exe");
                }

                if (r == "open chrome" || r =="open google chrome")
                {
                    Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
                }

                if (r == "open firefox" || r == "open mozilla firefox")
                {
                    Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe");
                }

                if (r == "open command prompt" || r == "open cmd")
                {
                    Process.Start(@"C:\Windows\system32\cmd.exe");
                }

                if (r == "open word")
                {
                    Process.Start(@"C:\Program Files\Microsoft Office\Office15\WINWORD.exe");
                }

                if (r == "open excel")
                {
                    Process.Start(@"C:\Program Files\Microsoft Office\Office15\EXCEL.exe");
                }

                if (r == "exit" || r == "quit")
                {
                    Environment.Exit(0);
                }

                if (r == "show help" || r == "show all commands" || r == "show commands")
                {
                    pictureBox1.Visible = true;
                }

                if (r == "hide help" || r == "hide all commands" || r == "hide commands")
                {
                    pictureBox1.Visible = false;
                }
            }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
