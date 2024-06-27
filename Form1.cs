using Microsoft.Web.WebView2.WinForms;
using static System.Net.WebRequestMethods;

namespace DiscordWV
{
    public partial class Discord : Form
    {
        public Discord()
        {
            InitializeComponent();
            textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = ((double)(trackBar1.Value) / 100.0);
            this.Text = (trackBar1.Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // this.webView21.Source = new Uri(textBox1.Text);

            string userInput = textBox1.Text;

            // Check if the input is empty
            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please enter a URL.");
                return;
            }

            try
            {
                // Ensure the URL is properly formatted
                UriBuilder uriBuilder = new UriBuilder(userInput);

                // Default to "http" if no scheme is provided
                if (string.IsNullOrWhiteSpace(uriBuilder.Scheme))
                {
                    uriBuilder.Scheme = Uri.UriSchemeHttp;
                }

                // Set the Source of the WebView to the cleaned URL
                this.webView21.Source = uriBuilder.Uri;
            }
            catch (UriFormatException ex)
            {
                // If the input is not a valid URL, treat it as a search term and use Google search
                string googleSearchUrl = $"https://www.google.com/search?q={Uri.EscapeDataString(userInput)}";
                this.webView21.Source = new Uri(googleSearchUrl);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the beep sound on Enter key press
                e.SuppressKeyPress = true;

                // Call the method to handle the URL or search term
                HandleUserInput();
            }
        }
        private void HandleUserInput()
        {
            string userInput = textBox1.Text;

            // Check if the input is empty
            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please enter a URL or search term.");
                return;
            }

            try
            {
                // Ensure the URL is properly formatted
                UriBuilder uriBuilder = new UriBuilder(userInput);

                // Default to "http" if no scheme is provided
                if (string.IsNullOrWhiteSpace(uriBuilder.Scheme))
                {
                    uriBuilder.Scheme = Uri.UriSchemeHttp;
                }

                // Set the Source of the WebView to the cleaned URL
                this.webView21.Source = uriBuilder.Uri;
            }
            catch (UriFormatException)
            {
                // If the input is not a valid URL, treat it as a search term and use Google search
                string googleSearchUrl = $"https://www.google.com/search?q={Uri.EscapeDataString(userInput)}";
                this.webView21.Source = new Uri(googleSearchUrl);
            }
        }
    }
}
