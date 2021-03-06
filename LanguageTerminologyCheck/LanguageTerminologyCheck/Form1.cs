using System;
using System.Windows.Forms;
using LanguageTerminologyCheck.TerminologyService;

namespace LanguageTerminologyCheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a collection to define the desired sources of translations             
            TranslationSources translationSources = new TranslationSources() {
                TranslationSource.Terms, TranslationSource.UiStrings
            };
            // Create the proxy for the Terminology Service SOAP client
            TerminologyClient service = new TerminologyService.TerminologyClient();
            try
            {
                // Call GetTranslations to get the results
                Matches results = service.GetTranslations("hello", "en-US", "es-ES", SearchStringComparison.CaseInsensitive, SearchOperator.Contains, translationSources, false, 20, true, null);
                // Use the results
                foreach (Match match in results)
                {
                    MessageBox.Show(match.OriginalText + "----" + match.Translations[0].TranslatedText);
                }
            } catch (Exception ex)
            {
                // do nothing
            }
        }
    }
}
// Aswini S

// https://www.microsoft.com/en-us/language/Microsoft-Terminology-API
