using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace The_Last_Days_Patcher
{
    public partial class Form1 : Form
    {
        //Const variables
        private const string DIRECTORY_BASE = "patcher-data";

        //Private variables
        private bool isPatchDoneSuccessfully = false;

        //Enums of script
        private enum UI_State
        {
            Default,
            Error,
        }

        //Private variables
        private string urlToGetSkinsIndex = "";
        private string pathToCachedImages = "";
        private string executableNameToLaunch = "";
        private string[] allPlayersUsernames = new string[0];

        public Form1()
        {
            InitializeComponent();

            //Register the code to run after window is shown
            Shown += firstStart_Shown;
            FormClosed += afterPatch_Close;
        }

        //UI methods
        private void firstStart_Shown(object sendr, EventArgs e)
        {
            //Initialize the patcher after render all window, recheaching in credit (last control)
            panelError.BeginInvoke(new Action(() => { 
                InitializePatcher(); 
            }));
        }

        private void afterPatch_Close(object sendr, EventArgs e)
        {
            //If the game is not patched, cancel execution
            if (isPatchDoneSuccessfully == false)
                return;

            //If the executable not exists
            if (File.Exists(executableNameToLaunch) == false)
                MessageBox.Show("Could not find executable \""+executableNameToLaunch+"\" in this Patcher directory. It will not open.", "Cannot open Launcher");
            //If the executable exists
            if (File.Exists(executableNameToLaunch) == true)
                Process.Start(executableNameToLaunch);
        }

        private void ChangeUITo(UI_State state)
        {
            //Change the ui to a state
            switch (state)
            {
                case UI_State.Default:
                    panelDefault.Visible = true;
                    panelError.Visible = false;
                    break;
                case UI_State.Error:
                    panelDefault.Visible = false;
                    panelError.Visible = true;
                    break;
            }
        }

        private void tryAgain_Click(object sender, EventArgs e)
        {
            //Restart the patcher
            InitializePatcher();
        }

        private void withoutPatch_Click(object sender, EventArgs e)
        {
            //Launch the minecraft launcher without patch
            isPatchDoneSuccessfully = true;

            //Finally close this patcher
            this.Close();
        }

        //Core methods

        private void InitializePatcher()
        {
            //Set default UI
            ChangeUITo(UI_State.Default);

            //Create needed files
            if (Directory.Exists(DIRECTORY_BASE) == false)
                Directory.CreateDirectory(DIRECTORY_BASE);
            if (Directory.Exists(DIRECTORY_BASE + "/skins_cache") == false)
                Directory.CreateDirectory(DIRECTORY_BASE + "/skins_cache");
            if (Directory.Exists(DIRECTORY_BASE + "/capes_cache") == false)
                Directory.CreateDirectory(DIRECTORY_BASE + "/capes_cache");
            if (Directory.Exists(DIRECTORY_BASE + "/_temp") == false)
                Directory.CreateDirectory(DIRECTORY_BASE + "/_temp");
            if (File.Exists(DIRECTORY_BASE + "/settings.txt") == false)
                File.WriteAllText(
                    DIRECTORY_BASE + "/settings.txt", 
                    "> URL to SkinsIndex.txt. The URL must have the \"!skins-index.txt\" file into, and all skins PNGs.\n"+
                    "https://example.com/skins-folder\n"+
                    "> Directory to cachedImages of your .minecraft of The Last Days Client.\n"+
                    "instances/The Last Days Client/.minecraft/cachedImages\n"+
                    "> Executable (.exe) file name (with extension) to be launched after patch be done.\n"+
                    "MultiMC.exe"
                    );

            //Read url to get skins index from file
            urlToGetSkinsIndex = File.ReadAllText(DIRECTORY_BASE + "/settings.txt").Split('\n')[1];
            //Read path to cached images
            pathToCachedImages = File.ReadAllText(DIRECTORY_BASE + "/settings.txt").Split('\n')[3];
            //Read executable name to be launched after patch
            executableNameToLaunch = File.ReadAllText(DIRECTORY_BASE + "/settings.txt").Split('\n')[5];

            //If cannot find the directory cachedImage and skins/capes folders, cancel execution of patcher
            if(Directory.Exists(pathToCachedImages + "/skins") == false || Directory.Exists(pathToCachedImages + "/capes") == false)
            {
                isPatchDoneSuccessfully = true;
                this.Close();
                return;
            }

            //Load all usernames list
            bool isSuccessfully = GetAllUsernamesListOfURL();
            if (isSuccessfully == false) //<-- If failed to download the skin-index, stop all downloads and show error
                return;

            //Clear cache of skins and capes
            DirectoryInfo skinsDirInfo = new DirectoryInfo(DIRECTORY_BASE + "/skins_cache");
            FileInfo[] skinsFiles = skinsDirInfo.GetFiles("*.png");
            foreach (FileInfo file in skinsFiles)
                File.Delete(DIRECTORY_BASE + "/skins_cache/" + file.Name);
            DirectoryInfo capesDirInfo = new DirectoryInfo(DIRECTORY_BASE + "/capes_cache");
            FileInfo[] capesFiles = capesDirInfo.GetFiles("*.png");
            foreach (FileInfo file in capesFiles)
                File.Delete(DIRECTORY_BASE + "/capes_cache/" + file.Name);

            //Download all skins from usernames list
            for (int i = 0; i < allPlayersUsernames.Length; i++)
            {
                bool isSucessfully = GetASkinOrCapeAndSaveInCache(i + 1, allPlayersUsernames[i]);
                Application.DoEvents();
                if (isSucessfully == false) //<-- If failed to download the skin or cape, stop all downloads and show error
                    return;
            }

            //Clear skins and capes folders of cachedImages
            DirectoryInfo cSkinsDirInfo = new DirectoryInfo(pathToCachedImages + "/skins");
            FileInfo[] cSkinsFiles = cSkinsDirInfo.GetFiles("*.png");
            foreach (FileInfo file in cSkinsFiles)
                File.Delete(pathToCachedImages + "/skins/" + file.Name);
            DirectoryInfo cCapesDirInfo = new DirectoryInfo(pathToCachedImages + "/capes");
            FileInfo[] cCapesFiles = cCapesDirInfo.GetFiles("*.png");
            foreach (FileInfo file in cCapesFiles)
                File.Delete(pathToCachedImages + "/capes/" + file.Name);

            //Copy all skins and capes downloaded to cachedImages
            DirectoryInfo dSkinsDirInfo = new DirectoryInfo(DIRECTORY_BASE + "/skins_cache");
            FileInfo[] dSkinsFiles = dSkinsDirInfo.GetFiles("*.png");
            foreach (FileInfo file in dSkinsFiles)
                File.Copy(DIRECTORY_BASE + "/skins_cache/" + file.Name, pathToCachedImages + "/skins/" + file.Name);
            DirectoryInfo dCapesDirInfo = new DirectoryInfo(DIRECTORY_BASE + "/capes_cache");
            FileInfo[] dCapesFiles = dCapesDirInfo.GetFiles("*.png");
            foreach (FileInfo file in dCapesFiles)
                File.Copy(DIRECTORY_BASE + "/capes_cache/" + file.Name, pathToCachedImages + "/capes/" + file.Name);

            //Set information of patch done successfully
            isPatchDoneSuccessfully = true;

            //Finally close this patcher
            this.Close();
        }

        //Tools methods

        private bool GetAllUsernamesListOfURL()
        {
            //create a new instance of WebClient
            WebClient client = new WebClient();

            //set the user agent to IE6
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)");
            try
            {
                //Get username list
                allPlayersUsernames = client.DownloadString(urlToGetSkinsIndex + "/!skins-index.txt").Split('\n');
                //Update progress bar data
                fileCount.Text = "000/" + allPlayersUsernames.Length.ToString("D3");
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Maximum = allPlayersUsernames.Length;
                progressBar.Value = 0;
                //Return sucess information
                return true;
            }
            catch (WebException we)
            {
                //WebException.Status holds useful information
                Console.WriteLine(we.Message + "\n" + we.Status.ToString());
                //Change ui to error
                ChangeUITo(UI_State.Error);
                //Return error information
                return false;
            }
            catch (NotSupportedException ne)
            {
                //Other errors
                Console.WriteLine(ne.Message);
                //Change ui to error
                ChangeUITo(UI_State.Error);
                //Return error information
                return false;
            }
        }
    
        private bool GetASkinOrCapeAndSaveInCache(int index, string skinName)
        {
            //create a new instance of WebClient
            WebClient client = new WebClient();

            //set the user agent to IE6
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)");
            try
            {
                //Clear temp file if exists
                if (File.Exists(DIRECTORY_BASE + "_temp/skin.png") == true)
                    File.Delete(DIRECTORY_BASE + "_temp/skin.png");
                //Get the skin
                client.DownloadFile(urlToGetSkinsIndex + "/" + skinName, DIRECTORY_BASE + "/_temp/skin.png");

                //If is a skin
                if (skinName.Contains("=cape") == false)
                {
                    string filePath = DIRECTORY_BASE +"/skins_cache/" + skinName;
                    if (File.Exists(filePath) == true)
                        File.Delete(filePath);
                    File.Move(DIRECTORY_BASE + "/_temp/skin.png", filePath);
                }
                //If is a cape
                if (skinName.Contains("=cape") == true)
                {
                    string filePath = DIRECTORY_BASE + "/capes_cache/" + skinName.Replace("=cape", "");
                    if (File.Exists(filePath) == true)
                        File.Delete(filePath);
                    File.Move(DIRECTORY_BASE + "/_temp/skin.png", filePath);
                }

                //Update progress bar data
                fileCount.Text = (index).ToString("D3") + "/" + allPlayersUsernames.Length.ToString("D3");
                progressBar.Value += 1;
                //Return sucess information
                return true;
            }
            catch (WebException we)
            {
                //WebException.Status holds useful information
                Console.WriteLine(we.Message + "\n" + we.Status.ToString());
                //Change ui to error
                ChangeUITo(UI_State.Error);
                //Return error information
                return false;
            }
            catch (NotSupportedException ne)
            {
                //Other errors
                Console.WriteLine(ne.Message);
                //Change ui to error
                ChangeUITo(UI_State.Error);
                //Return error information
                return false;
            }
        }
    }
}
