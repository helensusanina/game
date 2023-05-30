namespace WinFormsApp2
{
    public partial class Form1 : Form

    {
        System.Media.SoundPlayer startSound = new System.Media.SoundPlayer(@"C:\Windows\Media\chord.wav");
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startSound.Play();
            startFirstLevel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void startFirstLevel()
        {
            Form2 level = new();
            level.ShowDialog();
        }

    }
}