using FloidAlgoritm;
using System.Reflection;
using static System.Type;


namespace MauiAppMy
{
    public partial class MainPage : ContentPage
    {
        
        string sborkaAdress;
        bool assemblyStatus;
        private Assembly assembly;
        public MainPage()
        {
            InitializeComponent();
        }

        public void SborkaButtom_Clicked(object sender, EventArgs e)
        {
            sborkaAdress=SborkaLabel.Text;
            
            InstallAssembly();
            
        }

        private void InstallAssembly()
        {

            
            UploadNewDll();
            SborkaInformation.Text = "Получилось!!!";
            
        }
        

        private void UploadNewDll()
        {
            Assembly asm = Assembly.LoadFrom(SborkaLabel.Text);
            assembly = asm;
            CheckForContract(asm);
        }

        private void CheckForContract(Assembly asm)
        {
            Type[] types = asm.GetTypes();

            bool hasImplementation = types.Any(t => typeof(IFloid).IsAssignableFrom(t) && t.IsClass);

            assemblyStatus = hasImplementation;
        }
    }
}
