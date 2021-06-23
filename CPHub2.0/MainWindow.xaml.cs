using KeyDownTester.Keys;
using System;
using System.Collections.Generic;
//using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
using System.Windows.Input;
using Froms = System.Windows.Forms;
using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using CPHub;
using System.Drawing.Imaging;
//            _____                    _____                    _____                    _____                    _____          
//           /\    \                  /\    \                  /\    \                  /\    \                  /\    \         
//          /::\    \                /::\    \                /::\____\                /::\____\                /::\    \        
//         /::::\    \              /::::\    \              /:::/    /               /:::/    /               /::::\    \       
//        /::::::\    \            /::::::\    \            /:::/    /               /:::/    /               /::::::\    \      
//       /:::/\:::\    \          /:::/\:::\    \          /:::/    /               /:::/    /               /:::/\:::\    \     
//      /:::/  \:::\    \        /:::/__\:::\    \        /:::/____/               /:::/    /               /:::/__\:::\    \    
//     /:::/    \:::\    \      /::::\   \:::\    \      /::::\    \              /:::/    /               /::::\   \:::\    \   
//    /:::/    / \:::\    \    /::::::\   \:::\    \    /::::::\    \   _____    /:::/    /      _____    /::::::\   \:::\    \  
//   /:::/    /   \:::\    \  /:::/\:::\   \:::\____\  /:::/\:::\    \ /\    \  /:::/____/      /\    \  /:::/\:::\   \:::\ ___\ 
//  /:::/____/     \:::\____\/:::/  \:::\   \:::|    |/:::/  \:::\    /::\____\|:::|    /      /::\____\/:::/__\:::\   \:::|    |
//  \:::\    \      \::/    /\::/    \:::\  /:::|____|\::/    \:::\  /:::/    /|:::|____\     /:::/    /\:::\   \:::\  /:::|____|
//   \:::\    \      \/____/  \/_____/\:::\/:::/    /  \/____/ \:::\/:::/    /  \:::\    \   /:::/    /  \:::\   \:::\/:::/    / 
//    \:::\    \                       \::::::/    /            \::::::/    /    \:::\    \ /:::/    /    \:::\   \::::::/    /  
//     \:::\    \                       \::::/    /              \::::/    /      \:::\    /:::/    /      \:::\   \::::/    /   
//      \:::\    \                       \::/____/               /:::/    /        \:::\__/:::/    /        \:::\  /:::/    /    
//       \:::\    \                       ~~                    /:::/    /          \::::::::/    /          \:::\/:::/    /     
//        \:::\    \                                           /:::/    /            \::::::/    /            \::::::/    /      
//         \:::\____\                                         /:::/    /              \::::/    /              \::::/    /       
//          \::/    /                                         \::/    /                \::/____/                \::/____/        
//           \/____/                                           \/____/                  ~~                       ~~              
//                                                                                                                               
namespace CPHub2._0
{

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ImageWindow imagewin;


        private void Debug(string input)
        {
            System.Diagnostics.Debug.WriteLine(input);
        }

        /// <summary>
        /// Contains the captured clipboard contents
        /// </summary>
        public List<Copy> ListView { get; set; } = new List<Copy>();
        /// <summary>
        /// Contains the selected item filedroplist files icon and name
        /// </summary>
        public List<FilePropertes> FilesPropertiesProjector { get; set; }

        /// <summary>
        /// Contains all loaded colorpaletts
        /// </summary>
        public List<Color_> Colors { get; set; }

        private Froms.NotifyIcon notifyIcon;

        /// <summary>
        /// Make the context icon
        /// </summary>
        private void MakeContextIcon()
        {
            notifyIcon = new Froms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("Icons\\favicon-32x32.ico");
            notifyIcon.Text = "Open C&PHub";
            notifyIcon.Click += OpenWindiw;
            notifyIcon.Visible = true;
        }
        /// <summary>
        /// Open the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenWindiw(object sender, EventArgs e)
        {
            this.Activate();
            this.Topmost = true;
            this.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Disappears the context icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            notifyIcon.Dispose();
        }

        


        public CheckState _CheckState = new CheckState();

        

        public int UsedColorpalettIndex = 0;

        #region Color

        private string background_;
        public string Background_ 
        {
            get { return background_; }
            set 
            {
                background_ = value;
                OnPropertyChanged();

                
            }
        }
        
        public string Foreground_
        {
            get
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml(Background_);
                if (col.R * 0.2126 + col.G * 0.7152 + col.B * 0.0722 > 255 / 2)
                {
                    //dark color

                    return "black";
                }
                else
                {
                    //light color
                    return "white";
                }
            }
            set 
            {

            }
        }

        private string button1;
        public string Button1
        {
            get { return button1; }
            set 
            {
                button1 = value;
                OnPropertyChanged();
            } 
        }

        private string button2;
        public string Button2
        {
            get { return button2; }
            set
            {
                button2 = value;
                OnPropertyChanged();
            }
        }

        private string button3;
        public string Button3
        {
            get { return button3; }
            set
            {
                button3 = value;
                OnPropertyChanged();
            }
        }

        private string button4;
        public string Button4
        {
            get { return button4; }
            set
            {
                button4 = value;
                OnPropertyChanged();
            }
        }

        private string button5;
        public string Button5
        {
            get { return button5; }
            set
            {
                button5 = value;
                OnPropertyChanged();
            }
        }
        #endregion

        /// <summary>
        /// Read color paletts from the file
        /// </summary>
        public void ReadColorPaletts()
        {
            
            StreamReader sr = new StreamReader($"ColorPaletts.txt");
            string[] handler = new string[7];
            while (!sr.EndOfStream)
            {
                handler = sr.ReadLine().Split(',');
                
                Colors.Add(new Color_ { Color1 = handler[0], Color2 = handler[1], Color3 = handler[2], Color4 = handler[3], Color5 = handler[4], Color6 = handler[5], SetStatusz = string.Empty });
                if (handler[6] == "used")
                {
                    UsedColorpalettIndex = Colors.Count() - 1;
                }
            }
            sr.Close();
        }

        /// <summary>
        /// Get file icon
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns> the the file icon</returns>
        // Dose not work with folders 
        public System.Windows.Media.ImageSource GetFileIcon(string FilePath)
        {
            using (System.Drawing.Icon sysicon = System.Drawing.Icon.ExtractAssociatedIcon(FilePath))
            {


               return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(sysicon.Handle, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            }
        }

        /// <summary>
        /// Create Saves folder and ColorPaletts.txt
        /// </summary>
        private void CreateRequipments()
        {
            if (!Directory.Exists("Saves"))
            {
                Directory.CreateDirectory("Saves");
            }
            if (!File.Exists("ColorPaletts.txt"))
            {
                File.Create("ColorPaletts.txt");
                StreamWriter sw = new StreamWriter("ColorPaletts.txt");
                sw.WriteLine("#1d1d1d,#e84545,#903749,#4F518C,#53354a,#2b2e4a,used");
            }
        }

        public MainWindow()
        {
            //System.Diagnostics.Debugger.Launch();
            this.Colors = new List<Color_>();

            this.FilesPropertiesProjector = new List<FilePropertes>();

            CreateRequipments();

            ReadColorPaletts();

            #region Default color layout
            //Background_ = "#1d1d1d";
            //Button1 = "#e84545";
            //Button2 = "#903749";
            //Button3 = "#4F518C";
            //Button4 = "#53354a";
            //Button5 = "#2b2e4a";


            Background_ = Colors[UsedColorpalettIndex].Color1;
            Button1 = Colors[UsedColorpalettIndex].Color2;
            Button2 = Colors[UsedColorpalettIndex].Color3;
            Button3 = Colors[UsedColorpalettIndex].Color4;
            Button4 = Colors[UsedColorpalettIndex].Color5;
            Button5 = Colors[UsedColorpalettIndex].Color6;

            #endregion

            _CheckState = CheckState.CheckAll;

            this.Visibility = Visibility.Hidden;
            #region Set window size
            var ScreenSize = System.Windows.SystemParameters.WorkArea;
            
            this.Width = Convert.ToInt32(ScreenSize.Width / 3.415);
            this.Height = Convert.ToInt32(ScreenSize.Height / 3.415);
            #endregion


            #region set window position

            this.Top = ScreenSize.Height - 200;
            this.Left = ScreenSize.Width - 400;
            #endregion
            //this.ListView = new List<Copy>();

            InitializeComponent();

            this.DataContext = this;


            MakeContextIcon();

            
            LoadSavedItems();
           
            #region Add the current clipboard content
            //Image
            if (Clipboard.ContainsImage())
            {

                this.ListView.Add(new Copy {ContentType = "|Image" , ForegroundColor = this.Foreground_, CheckBoxState = false, CheckBoxVisibility = Visibility.Hidden, SaveStatusz = "Not Saved", Index = ListView.Count, Name = "Current ClipBoard Content", Image = Clipboard.GetImage() });
            }
            if (Clipboard.ContainsFileDropList())
            {
                //Files
                this.ListView.Add(new Copy {ContentType = "|Files" , ForegroundColor = this.Foreground_, CheckBoxState = false, CheckBoxVisibility = Visibility.Hidden, SaveStatusz = "Not Saved", Index = ListView.Count, Name = "Current ClipBoard Content", FilesPaths = Clipboard.GetFileDropList().Cast<string>().ToList() });
            }
            if (Clipboard.ContainsText())
            {
                //Text
                this.ListView.Add(new Copy {ContentType = "|Text" , ForegroundColor = this.Foreground_, CheckBoxState = false, CheckBoxVisibility = Visibility.Hidden, SaveStatusz = "Not Saved", Index = ListView.Count, Name = "Current ClipBoard Content", CopyContentText = Clipboard.GetText() });
            }


            #endregion

            #region register the hot key
            // need to setup the global hook. this can go in
            HotkeysManager.SetupSystemHook();

            // You can create a globalhotkey object and pass it like so                    Ide kell majd belerakni az a metódust ami kezeli a kiámsolt cuccot
            HotkeysManager.AddHotkey(new GlobalHotkey(ModifierKeys.Control, Key.C, () => { AddCopyToList(); }));

            // or do it like this. both end up doing the same thing, but this is probably simpler.
            //HotkeysManager.AddHotkey(ModifierKeys.Control, Key.A, () => { AddToList("Ctrl+A Fired"); });

            Closing += MainWindow_Closing;
            #endregion

        }


        /// <summary>
        /// Date
        /// </summary>
        /// <returns> The Date format</returns>
        public static string GetDate()
        {
            DateTime time = DateTime.Now;

            return string.Format("{0}.{1}.{2} {3}:{4}:{5}.{6}", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second, time.Millisecond);
        }

        public class Color_
        {
            public string Color1 { get; set; }
            public string Color2 { get; set; }
            public string Color3 { get; set; }
            public string Color4 { get; set; }
            public string Color5 { get; set; }
            public string Color6 { get; set; }
            public string SetStatusz { get; set; }
            public string ForeGround { get; set; }
        }

        public class Copy
        {
            //Megkülönböztetönk
            //Txt
            //Image
            //Html
            //FileDropList

            public int Index { get; set; }
            public string Name { get; set; }

            public string CopyContentText { get; set; }
            public List<string> FilesPaths { get; set; }
            public BitmapSource Image { get; set; }
            public string ContentType { get; set; }
            public string SaveStatusz { get; set; }
            public bool CheckBoxState { get; set; }
            public Visibility CheckBoxVisibility { get; set; }
            public string ForegroundColor { get; set; }

        }

        private string FindCopyType()
        {
            string handler = string.Empty;
            if(ListView[CopyList.SelectedIndex].CopyContentText != null)
            {
                handler = "text";
            }

            if(ListView[CopyList.SelectedIndex].Image != null)
            {
                handler = "image";
            }
            if(ListView[CopyList.SelectedIndex].FilesPaths != null)
            {
                handler = "file";
            }

            return handler;
        }

        /// <summary>
        /// Sets the slected item to the clipboard
        /// </summary>
        public void SetSelectedCopy()
        {
            switch (FindCopyType())
            {
                case "text":
                    Clipboard.SetText(ListView[CopyList.SelectedIndex].CopyContentText);
                    break;
                case "image":
                    Clipboard.SetImage(ListView[CopyList.SelectedIndex].Image);
                    break;
                case "file":
                    System.Collections.Specialized.StringCollection handler = new System.Collections.Specialized.StringCollection();
                    handler.AddRange(ListView[CopyList.SelectedIndex].FilesPaths.ToArray());
                    Clipboard.SetFileDropList( handler );
                    handler.Clear();
                    break;
            }


            //Clipboard.SetDataObject(ListView[CopyList.SelectedIndex].CopyContentText);
            
        }


        /// <summary>
        /// Change the file name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>the file real name without the extension</returns>
        private string LoadItemNameChanger(string name)
        {
            //alma.txt
            //return name.Substring(0, name.Length - 4);
            return name.Split(".")[0];
        }
        /// <summary>
        /// Load every saved copy from the folder 
        /// </summary>
        private void LoadSavedItems()
        {
            DirectoryInfo d = new DirectoryInfo("Saves");

            if (!d.Exists)
            {
                Directory.CreateDirectory("Saves");
            }
            List<FileInfo> files = d.GetFiles("*.txt").ToList();
            
            for (int i = 0; i < files.Count; i++)
            {
                if(File.ReadAllLines(string.Format("Saves\\{0}", files[i].Name))[0] == "paths") 
                {
                    string[] handler = File.ReadAllLines(string.Format("Saves\\{0}", files[i].Name)).Skip(1).ToArray();
                    this.ListView.Add(new Copy {FilesPaths = File.ReadAllLines(string.Format("Saves\\{0}", files[i].Name)).Skip(1).ToList(), ContentType = "|Files", ForegroundColor = this.Foreground_, CheckBoxVisibility = Visibility.Hidden, CheckBoxState = false, SaveStatusz = "Loaded", Name = LoadItemNameChanger(files[i].Name), Index = ListView.Count()});

                }
                else
                {
                   
                    this.ListView.Add(new Copy { ContentType = "|Text", ForegroundColor = this.Foreground_, CheckBoxVisibility = Visibility.Hidden, CheckBoxState = false, SaveStatusz = "Loaded", Name = LoadItemNameChanger(files[i].Name), Index = ListView.Count(), CopyContentText = File.ReadAllText(string.Format("Saves\\{0}", files[i].Name)) });

                    

                }
            }


            //Töröljök a listát
            files.Clear();

            files = d.GetFiles("*.png").ToList();
            
            for (int i = 0;i < files.Count; i++)
            {
                this.ListView.Add(new Copy { Image = (BitmapSource)PathToImage(string.Format("Saves\\{0}", files[i].Name)), ContentType = "|Image", ForegroundColor = this.Foreground_, CheckBoxVisibility = Visibility.Hidden, CheckBoxState = false, SaveStatusz = "Loaded", Name = LoadItemNameChanger(files[i].Name), Index = ListView.Count() });

            }
            files.Clear();

            files = d.GetFiles("*.jpg").ToList();

           

            for (int i = 0; i < files.Count; i++)
            {
                this.ListView.Add(new Copy { Image = (BitmapSource)PathToImage(string.Format("Saves\\{0}", files[i].Name)), ContentType = "|Image", ForegroundColor = this.Foreground_, CheckBoxVisibility = Visibility.Hidden, CheckBoxState = false, SaveStatusz = "Loaded", Name = LoadItemNameChanger(files[i].Name), Index = ListView.Count() });

            }
            
            CopyList.Items.Refresh();
            
        }



        /// <summary>
        /// Add the clipboard content to the list
        /// </summary>
        public void AddCopyToList()
        {

            //Image
            if (Clipboard.ContainsImage() || (PathIsImage(Clipboard.GetFileDropList().Cast<string>().ToArray()) && Clipboard.GetFileDropList().Count == 1))
            {

                if (PathIsImage(Clipboard.GetFileDropList().Cast<string>().ToArray()) && Clipboard.GetFileDropList().Count == 1)
                {
                    this.ListView.Add(new Copy { ContentType = "|Image", ForegroundColor = this.Foreground_, CheckBoxState = false, CheckBoxVisibility = Visibility.Hidden, SaveStatusz = "Not Saved", Index = ListView.Count, Name = GetDate(), Image = (BitmapSource)PathToImage() });

                }
                else 
                {
                    this.ListView.Add(new Copy { ContentType = "|Image", ForegroundColor = this.Foreground_, CheckBoxState = false, CheckBoxVisibility = Visibility.Hidden, SaveStatusz = "Not Saved", Index = ListView.Count, Name = GetDate(), Image = Clipboard.GetImage() });
                }

            }
            if (Clipboard.ContainsFileDropList() && PathIsImage(Clipboard.GetFileDropList().Cast<string>().ToArray()) == false)
            {
                //Files
                this.ListView.Add(new Copy {ContentType = "|Files" , ForegroundColor = this.Foreground_, CheckBoxState = false, CheckBoxVisibility = Visibility.Hidden, SaveStatusz = "Not Saved", Index = ListView.Count, Name = GetDate(), FilesPaths = Clipboard.GetFileDropList().Cast<string>().ToList() });
            }
            if (Clipboard.ContainsText())
            {
                //Text
                this.ListView.Add(new Copy { ContentType = "|Text", ForegroundColor = this.Foreground_, CheckBoxState = false, CheckBoxVisibility = Visibility.Hidden, SaveStatusz = "Not Saved", Index = ListView.Count, Name = GetDate(), CopyContentText = Clipboard.GetText() });
            }
           
            CopyList.Items.Refresh();



        }

       


        /// <summary>
        /// Set naming box text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CopyList.SelectedIndex != -1)
            {

                NameingBox.Text = ListView[CopyList.SelectedIndex].Name;

                //MoveToFirts();   
                SetSelectedCopy();
            }
        }
        //Ezzel felül irjuk az előzőt hogy lehessen paraméternélkül is használni
        private void ListViewItem_PreviewMouseLeftButtonDown()
        {
            if (CopyList.SelectedIndex != -1 && ListView.Count != 0)
            {

                NameingBox.Text = ListView[CopyList.SelectedIndex].Name;

                //MoveToFirts();
                Clipboard.SetText(string.Empty);
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Need to shutdown the hook. idk what happens if
            // you dont, but it might cause a memory leak.
            HotkeysManager.ShutdownSystemHook();
        }

        /// <summary>
        /// Remove selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remove(object sender, RoutedEventArgs e)
        {
            ListView.RemoveAt(CopyList.SelectedIndex);

            CopyList.SelectedIndex = 0;
            //Ez azért kell hogy a list elejére kerüljön meg stb
            ListViewItem_PreviewMouseLeftButtonDown();
            NameingBox.Text = string.Empty;
            CopyList.Items.Refresh();
        }

        /// <summary>
        /// Save selected Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save(object sender, RoutedEventArgs e)
        {
            //text
            if (ListView[CopyList.SelectedIndex].CopyContentText != null)
            {
                using (FileStream fs = File.Create(string.Format("Saves\\{0}.txt", ListView[CopyList.SelectedIndex].Name.Replace(':', '_'))))
                {
                    byte[] handler = new UTF8Encoding(true).GetBytes(ListView[CopyList.SelectedIndex].CopyContentText);
                    fs.Write(handler, 0, handler.Length);
                }
                ListView[CopyList.SelectedIndex].SaveStatusz = "Saved";
                CopyList.Items.Refresh();
            }
            //fileok
            if (ListView[CopyList.SelectedIndex].FilesPaths != null && (ListView[CopyList.SelectedIndex].Image == null))
            {

                using (FileStream fs = File.Create(string.Format("Saves\\{0}.txt", ListView[CopyList.SelectedIndex].Name.Replace(':', '_'))))
                {
                    byte[] handler = new UTF8Encoding(true).GetBytes(string.Join("\n", ListView[CopyList.SelectedIndex].FilesPaths));
                    fs.Write(new UTF8Encoding(true).GetBytes("paths\n"), 0, new UTF8Encoding(true).GetBytes("paths\n").Length);
                    fs.Write(handler, 0, handler.Length);
                }
                ListView[CopyList.SelectedIndex].SaveStatusz = "Saved";
                CopyList.Items.Refresh();
            }
            //kép
            if (ListView[CopyList.SelectedIndex].Image != null)
            {


                if (PathIsImage(ListView[CopyList.SelectedIndex].FilesPaths))
                {
                    //PathToImage();
                    string[] handler = ListView[CopyList.SelectedIndex].FilesPaths[0].Split("\\");
                    string[] handler2 = handler.Last().Split(".");

                    System.IO.File.Copy(ListView[CopyList.SelectedIndex].FilesPaths[0], string.Format("Saves\\{0}.{1}", ListView[CopyList.SelectedIndex].Name.Replace(':', '_'), handler2[1]));
                   
                }
                else
                {

                    BitmapSource m = (BitmapSource)ListView[CopyList.SelectedIndex].Image;

                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(m.PixelWidth, m.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb); // Pit: Select Format32bppRgb will not have transparency

                    System.Drawing.Imaging.BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                    m.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
                    bmp.UnlockBits(data);

                    
                   

                   bmp.Save(string.Format("Saves\\{0}.jpg", ListView[CopyList.SelectedIndex].Name.Replace(':', '_')), ImageFormat.Jpeg);
                }
                

            }

            ListView[CopyList.SelectedIndex].SaveStatusz = "Saved";
            CopyList.Items.Refresh();


        }

        public class FilePropertes
        {
            public System.Windows.Media.ImageSource Icon { get; set; }
            public string Name { get; set; }
            public string ForegroundColor { get; set; }
        }

        /// <summary>
        /// Checks the path is an image
        /// </summary>
        /// <returns>true if path is an image</returns>
        private bool PathIsImage(string[] path)
        {
            bool handler = false;
            if(path.Length == 1)
            {
                if (path[0].Split("\\").Last().Contains("png") || path[0].Split("\\").Last().Contains("jpg"))
                {
                    handler = true;
                }
            }
            return handler;
        }

        private bool PathIsImage(List<string> path)
        {
            bool handler = false;
            
            if(path == null) { return handler; }

            if (path.Count == 1)
            {
                if (path[0].Split("\\").Last().Contains("png") || path[0].Split("\\").Last().Contains("jpg"))
                {
                    handler = true;
                }
            }
            return handler;
        }

        /// <summary>
        /// Gets the image from current clipboard filedroplist first element
        /// </summary>
        /// <returns>the copyed image</returns>
        private ImageSource PathToImage()
        {
            BitmapImage handler = new BitmapImage();
            handler.BeginInit();
            handler.CacheOption = BitmapCacheOption.OnLoad;
            handler.UriSource = new Uri(Clipboard.GetFileDropList()[0].Replace("\\", "/"));
            handler.EndInit();

            
            return handler;
        }

        /// <summary>
        /// Gets the image frpom the path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>image</returns>
        private ImageSource PathToImage(string path)
        {
            
            BitmapImage handler = new BitmapImage();
            handler.BeginInit();
            handler.CacheOption = BitmapCacheOption.OnLoad;
            handler.UriSource = new Uri(path.Replace("\\", "/"), UriKind.Relative);
            handler.EndInit();
            //return new BitmapImage(new Uri(path.Replace("\\", "/"), UriKind.Relative));
            return handler;
        }
        

        /// <summary>
        /// Show the selected item content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Show(object sender, RoutedEventArgs e)
        {
            
            //Text
            if (ListView[CopyList.SelectedIndex].CopyContentText != null)
            {

                ShowText.Text = ListView[CopyList.SelectedIndex].CopyContentText;
                ShowPanel.Visibility = Visibility.Visible;
            }
            if (ListView[CopyList.SelectedIndex].FilesPaths != null && (ListView[CopyList.SelectedIndex].Image == null))
            {
                FilesPropertiesProjector.Clear();
                for (int i = 0; i < ListView[CopyList.SelectedIndex].FilesPaths.Count; i++)
                {
                    if (ListView[CopyList.SelectedIndex].FilesPaths[i].Split("\\").Last().Contains("."))
                    {

                        FilesPropertiesProjector.Add(new FilePropertes { ForegroundColor = "white", Icon = GetFileIcon(@ListView[CopyList.SelectedIndex].FilesPaths[i]), Name = ListView[CopyList.SelectedIndex].FilesPaths[i].Split("\\").Last() });
                    }
                    else
                    {
                        
                        FilesPropertiesProjector.Add(new FilePropertes { ForegroundColor = "white", Name = ListView[CopyList.SelectedIndex].FilesPaths[i].Split("\\").Last() });

                    }
                }

                FilePanel.Items.Refresh();
                ShowFilePanel.Visibility = Visibility.Visible;
            }
            //Debug((ListView[CopyList.SelectedIndex].FilesPaths == null).ToString());
            if (ListView[CopyList.SelectedIndex].Image != null)
            {
                
                this.imagewin = new ImageWindow(ListView[CopyList.SelectedIndex].Image);
                this.imagewin.Show();
                

            }
            
            
        }

        /// <summary>
        /// Set the selected item name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameingBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && ListView.Count != 0)
            {

                ListView[CopyList.SelectedIndex].Name = NameingBox.Text;
                CopyList.Items.Refresh();
            }

        }

        
        /// <summary>
        /// Close The text panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseTextPanel(object sender, RoutedEventArgs e)
        {
           
            
            ShowText.Text = string.Empty;
            ShowPanel.Visibility = Visibility.Hidden;

            FilesPropertiesProjector.Clear();
            ShowFilePanel.Visibility = Visibility.Hidden;
            
        }

        /// <summary>
        /// Check all items
        /// </summary>
        private void CheckAll(bool IsCheck)
        {
            for (int i = 0; i < ListView.Count; i++)
            {
                ListView[i].CheckBoxState = IsCheck;
            }
        }

        /// <summary>
        /// Change the checkbox vissibility
        /// </summary>
        /// <param name="vs"></param>
        private void ChangeVisibility(Visibility vs)
        {
            for (int i = 0; i < ListView.Count; i++)
            {
                ListView[i].CheckBoxVisibility = vs;
            }
        }

        //Bővításre szorul
        /// <summary>
        /// Remove all chacked item from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAll(object sender, RoutedEventArgs e)
        {
            ChangeVisibility(Visibility.Hidden);

            NameingBox.Text = string.Empty;

            _CheckState = CheckState.CheckAll;
            CheckButton.ToolTip = "Click To UnCheck All";

            for (int i = 0; i < ListView.Count; i++)
            {
                if (ListView[i].CheckBoxState == true)
                {
                    //Amikor itt törlünk valamit akkor az i ből ki kell vonni egyet
                    ListView.RemoveAt(i);
                    i--;
                }
            }

            CheckAll(false);

            CopyList.Items.Refresh();
        }

        /// <summary>
        /// Delete the saved items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAll(object sender, RoutedEventArgs e)
        {
            ChangeVisibility(Visibility.Hidden);

            NameingBox.Text = string.Empty;

            _CheckState = CheckState.CheckAll;
            CheckButton.ToolTip = "Click To UnCheck All";

            for (int i = 0; i < ListView.Count; i++)
            {
                if (ListView[i].CheckBoxState == true)
                {
                    
                    if (File.Exists(string.Format("Saves\\{0}.txt", ListView[i].Name.Replace(':', '_'))))
                    {
                        File.Delete(string.Format("Saves\\{0}.txt", ListView[i].Name.Replace(':', '_')));
                    }

                    if (File.Exists(string.Format("Saves\\{0}.png", ListView[i].Name.Replace(':', '_'))))
                    {
                        File.Delete(string.Format("Saves\\{0}.png", ListView[i].Name.Replace(':', '_')));
                    }
                    if (File.Exists(string.Format("Saves\\{0}.jpg", ListView[i].Name.Replace(':', '_'))))
                    {
                        File.Delete(string.Format("Saves\\{0}.jpg", ListView[i].Name.Replace(':', '_')));
                    }

                    ListView[i].SaveStatusz = "Not Saved";
                    CopyList.Items.Refresh();
                }
            }

            CheckAll(false);

            CopyList.Items.Refresh();
        }

        /// <summary>
        /// Delete saved and selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSelectedCopy(object sender, RoutedEventArgs e)
        {

            if (File.Exists(string.Format("Saves\\{0}.txt", ListView[CopyList.SelectedIndex].Name.Replace(':', '_'))))
            {
                File.Delete(string.Format("Saves\\{0}.txt", ListView[CopyList.SelectedIndex].Name.Replace(':', '_')));  
            }

            if (File.Exists(string.Format("Saves\\{0}.png", ListView[CopyList.SelectedIndex].Name.Replace(':', '_'))))
            {
                File.Delete(string.Format("Saves\\{0}.png", ListView[CopyList.SelectedIndex].Name.Replace(':', '_')));
            }
            if (File.Exists(string.Format("Saves\\{0}.jpg", ListView[CopyList.SelectedIndex].Name.Replace(':', '_'))))
            {
                File.Delete(string.Format("Saves\\{0}.jpg", ListView[CopyList.SelectedIndex].Name.Replace(':', '_')));
            }

            ListView[CopyList.SelectedIndex].SaveStatusz = "Not Saved";
            CopyList.Items.Refresh();
        }

        /// <summary>
        /// Close application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseApp(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// Hide full application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideApp(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }



        //Ennek egy 3 álásó/ funkciós gombnak kell leni
        //1. chechk all
        //2. uncheck all
        //3. hide check
        
        public enum CheckState
        {
            CheckAll,
            UnCheckAll,
            HideCheckBox
        }

        /// <summary>
        /// Change the check button state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            //CheckButton.Content = _CheckState.ToString();

            switch (_CheckState)
            {
                case CheckState.CheckAll:

                    CheckAll(true);
                    ChangeVisibility(Visibility.Visible);

                    _CheckState = CheckState.UnCheckAll;

                    CheckButton.ToolTip = "Click To UnCheck All";
                    CopyList.Items.Refresh();
                    break;
                case CheckState.UnCheckAll:
                    CheckAll(false);
                    ChangeVisibility(Visibility.Visible);
                    _CheckState = CheckState.HideCheckBox;

                    CheckButton.ToolTip = "Click To Hide Check Boxes";
                    CopyList.Items.Refresh();
                    break;
                case CheckState.HideCheckBox:
                    ChangeVisibility(Visibility.Hidden);
                    CheckButton.ToolTip = "Click To Check All";
                    _CheckState = CheckState.CheckAll;
                    CopyList.Items.Refresh();
                    break;
            }
        }

        private void SaveAllCheckedCopy(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < ListView.Count; i++)
            {

                if (ListView[i].CheckBoxState == true)
                {
                    //text
                    if (ListView[i].CopyContentText != null)
                    {
                        using (FileStream fs = File.Create(string.Format("Saves\\{0}.txt", ListView[i].Name.Replace(':', '_'))))
                        {
                            byte[] handler = new UTF8Encoding(true).GetBytes(ListView[i].CopyContentText);
                            fs.Write(handler, 0, handler.Length);
                        }
                        ListView[i].SaveStatusz = "Saved";
                        CopyList.Items.Refresh();
                    }
                    //fileok
                    if (ListView[i].FilesPaths != null && (ListView[i].Image == null))
                    {

                        using (FileStream fs = File.Create(string.Format("Saves\\{0}.txt", ListView[i].Name.Replace(':', '_'))))
                        {
                            byte[] handler = new UTF8Encoding(true).GetBytes(string.Join("\n", ListView[i].FilesPaths));
                            fs.Write(new UTF8Encoding(true).GetBytes("paths\n"), 0, new UTF8Encoding(true).GetBytes("paths\n").Length);
                            fs.Write(handler, 0, handler.Length);
                        }
                        ListView[i].SaveStatusz = "Saved";
                        CopyList.Items.Refresh();
                    }
                    //kép
                    if (ListView[i].Image != null)
                    {


                        if (PathIsImage(ListView[i].FilesPaths))
                        {
                            //PathToImage();
                            string[] handler = ListView[i].FilesPaths[0].Split("\\");
                            string[] handler2 = handler.Last().Split(".");

                            System.IO.File.Copy(ListView[i].FilesPaths[0], string.Format("Saves\\{0}.{1}", ListView[CopyList.SelectedIndex].Name.Replace(':', '_'), handler2[1]), true);
                            //File.SetAttributes(string.Format("Saves\\{0}.{1}", ListView[CopyList.SelectedIndex].Name.Replace(':', '_')), FileAttributes.Normal);

                        }
                        else
                        {

                            BitmapSource m = (BitmapSource)ListView[i].Image;

                            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(m.PixelWidth, m.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb); // Pit: Select Format32bppRgb will not have transparency

                            System.Drawing.Imaging.BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                            m.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
                            bmp.UnlockBits(data);




                            bmp.Save(string.Format("Saves\\{0}.jpg", ListView[i].Name.Replace(':', '_')), ImageFormat.Jpeg);
                        }


                    }

                    ListView[i].SaveStatusz = "Saved";
                    CopyList.Items.Refresh();
                }


            }





            CheckAll(false);
            ChangeVisibility(Visibility.Hidden);
            _CheckState = CheckState.CheckAll;
            CheckButton.ToolTip = "Click To UnCheck All";
            CopyList.Items.Refresh();
        }

        /// <summary>
        /// Hide settings menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideSettings(object sender, RoutedEventArgs e)
        {
            SettingsMenu.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Show settings menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowSettings(object sender, RoutedEventArgs e)
        {
            SettingsMenu.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Set and save the checked colorpalett
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorPalettItem(object sender, MouseButtonEventArgs e)
        {
            //color1 = background, a többbi szin a gombok fentről le fele
            this.Background_ = Colors[ColorList.SelectedIndex].Color1;
            this.Button1 = Colors[ColorList.SelectedIndex].Color2;
            this.Button2 = Colors[ColorList.SelectedIndex].Color3;
            this.Button3 = Colors[ColorList.SelectedIndex].Color4;
            this.Button4 = Colors[ColorList.SelectedIndex].Color5;
            this.Button5 = Colors[ColorList.SelectedIndex].Color6;

            StreamReader sr = new StreamReader($"ColorPaletts.txt");
            List<string[]> handler = new List<string[]>();

            while (!sr.EndOfStream)
            {
                handler.Add(sr.ReadLine().Split(",") );
            }
            sr.Close();

            for(int i = 0; i < handler.Count; i++)
            {
                if(handler[i][6] == "used")
                {
                    handler[i][6] = string.Empty;
                }
            }

            string handler2 = string.Empty;
            StreamWriter sw = new StreamWriter($"ColorPaletts.txt");

            for(int i = 0; i < handler.Count; i++)
            {
                if(i == ColorList.SelectedIndex)
                {
                    handler2 = string.Join(",", handler[i])+"used";
                    sw.WriteLine(handler2);
                }
                else
                {
                    handler2 = string.Join(",", handler[i]);
                    sw.WriteLine(handler2);
                }

                
            }
            sw.Close();

        }
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        
    }
}
