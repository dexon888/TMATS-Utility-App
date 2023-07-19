using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics;
using System.Net.Sockets;

namespace TMATDashboardApp
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private TcpListener listener;
        public Form1()
        {
            client = new TcpClient();
            InitializeComponent();
        }

        private void inputBtn_Click(object sender, EventArgs e)
        {
            string file = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                output_file_path(sender, e, file, file_box);
            }
        }

        private void output_file_path(object sender, EventArgs e, string file, TextBoxBase textbox)
        {
            textbox.Text = file;
        }

        private void raw_btn_Click(object sender, EventArgs e)
        {
            string filename = file_box.Text;
            System.IO.File.WriteAllText("raw.txt", string.Empty);
            if (filename.Contains(".ch10"))
            {
                create_output(" raw.txt", " -r", file_box);

                Thread.Sleep(1000);
                string[] lines = System.IO.File.ReadAllLines("raw.txt");
                string separator = "\n";
                outputBox.Text = string.Join(separator, lines);
                System.IO.File.WriteAllText("raw.txt", string.Empty);
            }
            else if (file_box.Text == "")
            {
                MessageBox.Show("Please enter the specified file");
            }
            else
            {
                MessageBox.Show("The file is not a Chapter 10 File");
                file_box.Clear();
                outputBox.Clear();
            }
        }

        internal class TMATSFile
        {
            internal string ParameterName;
            internal int IncrementColumns;
            internal int IncrementRows;
            internal int InitialColumn;
            internal int EndColumn;
            internal int InitialRow;
            internal int EndRow;

            internal TMATSFile(string ParameterName, int IncrementColumns, int IncrementRows, int InitialColumn, int EndColumn, int InitialRow, int EndRow)
            {
                this.ParameterName = ParameterName;
                this.IncrementColumns = IncrementColumns;
                this.IncrementRows = IncrementRows;
                this.InitialColumn = InitialColumn;
                this.EndColumn = EndColumn;
                this.InitialRow = InitialRow;
                this.EndRow = EndRow;
            }

            public override string ToString()
            {
                return this.ParameterName + "," + this.IncrementColumns + "," + this.InitialColumn + "," + this.EndColumn + "," + this.IncrementRows
                        + "," + this.InitialRow + "," + this.EndRow;
            }
        }
        private void tree_btnClick(object sender, EventArgs e)
        {

            /*
            TMATSFile test = new TMATSFile("Altitude", 2, 1, 5, 2, 0, 3, 5, 4);
            TMATSFile test2 = new TMATSFile("Depth", 3, 2, 5, 0, 1, 3, 5, 6);
            TMATSFile test3 = new TMATSFile("Speed", 5, 0, 1, 3, 2, 1, 3, 2);*/

            StringBuilder output = new StringBuilder();
            /*output.AppendLine(test.toString());
            output.AppendLine(test2.toString());
            output.AppendLine(test3.toString());*/

            //Get the current count for each paramater
            int count = 1;

            //Establish an array of the lines of a Chapter 10 file
            string filename = file_box.Text;
            System.IO.File.WriteAllText("raw.txt", string.Empty);
            if (filename.Contains(".ch10"))
            {
                create_output(" raw.txt", " -r", file_box);

                Thread.Sleep(1000);
                string[] lines = System.IO.File.ReadAllLines("raw.txt");
                string separator = "\n";
                outputBox.Text = string.Join(separator, lines);
                System.IO.File.WriteAllText("raw.txt", string.Empty);

                String name = "";
                int incrementCol = 0;
                int incrementRow = 0;
                int initialCol = 0;
                int initialRow = 0;
                int endingCol = 0;
                int endingRow = 0;
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains($"D-{count}"))
                    {
                        if (lines[i].Contains($"D-{count}\\DLN"))
                        {
                            name = lines[i].Substring(lines[i].IndexOf(':') + 1);
                        }

                        if (lines[i].Contains($"D-{count})\\WI-y-n-m-e)"))
                        {
                            incrementCol = Int32.Parse(lines[i].Substring(lines[i].IndexOf(':') + 1));
                        }
                        else
                        {
                            incrementCol = 0;
                        }

                        if (lines[i].Contains($"D-{count})\\WP-y-n-m-e)"))
                        {
                            initialCol = Int32.Parse(lines[i].Substring(lines[i].IndexOf(':') + 1));
                        }

                        if (lines[i].Contains($"D-{count})\\EWP-y-n-m-e)"))
                        {
                            endingCol = Int32.Parse(lines[i].Substring(lines[i].IndexOf(':') + 1));
                        }

                        if (lines[i].Contains($"D-{count})\\FI-y-n-m-e)"))
                        {
                            incrementRow = Int32.Parse(lines[i].Substring(lines[i].IndexOf(':') + 1));
                        }

                        if (lines[i].Contains($"D-{count})\\FP-y-n-m-e)"))
                        {
                            initialRow = Int32.Parse(lines[i].Substring(lines[i].IndexOf(':') + 1));
                        }

                        if (lines[i].Contains($"D-{count})\\EFP-y-n-m-e)"))
                        {
                            endingRow = Int32.Parse(lines[i].Substring(lines[i].IndexOf(':') + 1));
                            count++;
                            TMATSFile input = new TMATSFile(name, incrementCol, incrementRow, initialCol, endingCol, initialRow, endingRow);
                            output.AppendLine(input.ToString());
                        }

                    }

                }
                String file = $"{filename.Substring(0, filename.IndexOf("."))}.csv";
                //Write the data into a CSV file
                try
                {
                    File.WriteAllText(file, output.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data could not be written to the CSV file. Exception: " + ex.Message);
                    return;
                }

                MessageBox.Show("CSV created.");
            }
            else if (file_box.Text == "")
            {
                MessageBox.Show("Please enter the specified file");
            }
            else
            {
                MessageBox.Show("The file is not a Chapter 10 File");
                file_box.Clear();
                outputBox.Clear();
            }




        }

        private void send_Click(object sender, EventArgs e)
        {
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "CSV Files (*.csv)|*.csv";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        byte[] fileBytes = File.ReadAllBytes(filePath);

                        try
                        {
                            // Ensure the client is connected to the server before sending data
                            if (!client.Connected)
                            {
                                client.Connect("127.0.0.1", 1234); // Replace with server's IP address
                            }

                            NetworkStream networkStream = client.GetStream();

                            networkStream.Write(fileBytes, 0, fileBytes.Length);
                            networkStream.Flush();

                            MessageBox.Show("File sent successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while sending the file: " + ex.Message);
                        }
                    }
                }
            }
        }
        private async void receive_Click(object sender, EventArgs e)
        {
            int port = 1234; // Server listening port number

            try
            {
                // Ensure the client is connected to the server before receiving data
                if (!client.Connected)
                {
                    await client.ConnectAsync("127.0.0.1", port); // Replace with server's IP address
                    Console.WriteLine("Client connected to the server.");
                }

                NetworkStream networkStream = client.GetStream();

                byte[] buffer = new byte[1024]; // buffer size
                int bytesRead;
                MemoryStream memoryStream = new MemoryStream();

                while ((bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await memoryStream.WriteAsync(buffer, 0, bytesRead);
                }

                byte[] receivedBytes = memoryStream.ToArray();

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        File.WriteAllBytes(filePath, receivedBytes);
                        MessageBox.Show("File received and saved successfully.");
                        Console.WriteLine("File received and saved to: " + filePath);
                    }
                }

                memoryStream.Close();
                networkStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while receiving the file: " + ex.Message);
                Console.WriteLine("Error occurred while receiving the file: " + ex.Message);
            }
        }


        private void clearBtn_Click(object sender, EventArgs e)
        {
            file_1_box.Clear();
            file_2_box.Clear();
            file_box.Clear();
            outputBox.Clear();
        }

        private void splitBtnClick(object sender, EventArgs e)
        {
            string filename = file_box.Text;
            if (filename.Contains(".ch10"))
            {
                /*create_output(" raw.txt", " -r", file_box);
                Thread.Sleep(5000);
                string[] raw = System.IO.File.ReadAllLines("raw.txt");*/

                string[] raw = chapter10_parser(file_box);

                List<string> output_array = new List<string>();
                Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
                List<string> g_group = new List<string>();




                int number_of_data_sources = 0;

                // Find number of data sources
                for (int i = 0; i < raw.Length; i++)
                {
                    if (raw[i].Contains("G\\DSI\\N:"))
                    {
                        number_of_data_sources = Int32.Parse(raw[i].Substring(raw[i].LastIndexOf(':') + 1, 1));

                    }
                }

                // Find the G-Group entries     
                for (int i = 0; i < raw.Length; i++)
                {
                    if (raw[i].StartsWith("G\\") && !raw[i].Contains("="))
                    {
                        g_group.Add(raw[i].Trim());
                    }
                }

                int r_id = 1;
                List<string> r_group = new List<string>();
                List<string> t_group = new List<string>();
                Dictionary<string, int> p_datalink = new Dictionary<string, int>();
                List<string> p_group = new List<string>();

                List<int> number_R_groups = new List<int>();

                int R_stream_count = 0;

                // Find the number of R-streams or T-streams
                for (int i = 0; i < g_group.Count(); i++)
                {
                    if (g_group[i].Contains("G\\DSI\\"))
                    {
                        R_stream_count = Int32.Parse(g_group[i].Substring(g_group[i].LastIndexOf(":") + 1).Replace(";", ""));
                    }
                }

                Dictionary<string, int> b_datalink = new Dictionary<string, int>();
                Dictionary<string, int> datasource = new Dictionary<string, int>();
                // Find the R-Entries for each output file
                while (r_id <= R_stream_count)
                {
                    for (int i = 0; i < raw.Length; i++)
                    {
                        if (raw[i].StartsWith($"R-{r_id}\\"))
                        {
                            r_group.Add(raw[i]);

                            if (raw[i].Contains("\\ID:"))
                            {
                                datasource.Add(raw[i].Substring(raw[i].LastIndexOf(":") + 1).Replace(";", ""), r_id);
                            }
                            if (raw[i].Contains("\\PDLN-"))
                            {
                                p_datalink.Add(raw[i].Substring(raw[i].LastIndexOf(":") + 1).Replace(";", ""), r_id);
                            }
                            if (raw[i].Contains("\\BDLN-"))
                            {
                                b_datalink.Add(raw[i].Substring(raw[i].LastIndexOf(":") + 1).Replace(";", ""), r_id);
                            }

                        }
                        if (raw[i].StartsWith($"T-{r_id}\\"))
                        {
                            t_group.Add(raw[i]);

                            if (raw[i].Contains("\\ID:"))
                            {
                                datasource.Add(raw[i].Substring(raw[i].LastIndexOf(":") + 1).Replace(";", ""), r_id);
                            }
                            if (raw[i].Contains("\\PDLN:"))
                            {
                                p_datalink.Add(raw[i].Substring(raw[i].LastIndexOf(":") + 1).Replace(";", ""), r_id);
                            }
                            if (raw[i].Contains("\\BDLN-"))
                            {
                                b_datalink.Add(raw[i].Substring(raw[i].LastIndexOf(":") + 1).Replace(";", ""), r_id);
                            }

                        }

                    }
                    var result = g_group.Concat(r_group).Concat(t_group);
                    File.WriteAllLines($"output{r_id}.txt", result);
                    r_id++;
                    r_group.Clear();
                    t_group.Clear();
                }



                if (p_datalink.Count() == 0)
                {
                    int m_id = 0;
                    Dictionary<int, int> m_location = new Dictionary<int, int>();
                    List<string> m_group = new List<string>();
                    foreach (string data in datasource.Keys)
                    {
                        for (int i = 0; i < raw.Length; i++)
                        {
                            if (raw[i].StartsWith("M-") && raw[i].Contains("\\ID:" + data))
                            {
                                var start = raw[i].IndexOf("-") + 1;
                                m_id = Int32.Parse(raw[i].Substring(start, raw[i].IndexOf("\\") - start));
                                m_location.Add(m_id, datasource[data]);
                            }
                        }
                    }
                    foreach (int data in m_location.Keys)
                    {
                        for (int i = 0; i < raw.Length; i++)
                        {
                            if (raw[i].StartsWith($"M-{data}\\"))
                            {
                                m_group.Add(raw[i]);
                                if (raw[i].Contains("\\DLN:") && !datasource.ContainsKey(raw[i].Substring(raw[i].LastIndexOf(":") + 1).Replace(";", "")))
                                {
                                    p_datalink.Add(raw[i].Substring(raw[i].LastIndexOf(":") + 1).Replace(";", ""), data);
                                }
                            }
                        }
                    }
                }

                int b_id = 0;
                Dictionary<int, int> b_location = new Dictionary<int, int>();
                List<string> b_group = new List<string>();
                if (b_datalink.Count() > 0)
                {
                    foreach (string data in b_datalink.Keys)
                    {
                        for (int i = 0; i < raw.Length; i++)
                        {
                            if (raw[i].StartsWith("B-") && raw[i].Contains("\\DLN:" + data))
                            {
                                var start = raw[i].IndexOf("-") + 1;
                                b_id = Int32.Parse(raw[i].Substring(start, raw[i].IndexOf("\\") - start));
                                b_location.Add(b_id, b_datalink[data]);
                            }
                        }
                    }
                    foreach (int data in b_location.Keys)
                    {
                        for (int i = 0; i < raw.Length; i++)
                        {
                            if (raw[i].StartsWith($"B-{data}\\"))
                            {
                                b_group.Add(raw[i]);
                            }
                        }
                        File.AppendAllLines($"output{b_location[data]}.txt", b_group);
                        b_group.Clear();
                    }

                }


                // Finds P_group and D_group DLN entries so that we can extract the other P and D entries
                Dictionary<int, int> p_location = new Dictionary<int, int>();
                Dictionary<int, int> d_location = new Dictionary<int, int>();
                List<string> d_group = new List<string>();
                int p_id = 0;
                int d_id = 0;

                foreach (string data in p_datalink.Keys)
                {
                    for (int i = 0; i < raw.Length; i++)
                    {
                        if (raw[i].StartsWith("P-") && raw[i].Contains("\\DLN:" + data))
                        {
                            var start = raw[i].IndexOf("-") + 1;
                            p_id = Int32.Parse(raw[i].Substring(start, raw[i].IndexOf("\\") - start));
                            p_location.Add(p_id, p_datalink[data]);
                        }

                        if (raw[i].StartsWith("D-") && raw[i].Contains("\\DLN:" + data))
                        {
                            var start = raw[i].IndexOf("-") + 1;
                            d_id = Int32.Parse(raw[i].Substring(start, raw[i].IndexOf("\\") - start));
                            d_location.Add(p_id, p_datalink[data]);
                        }
                    }
                }

                // Appends the P-entries
                foreach (int data in p_location.Keys)
                {
                    for (int i = 0; i < raw.Length; i++)
                    {
                        if (raw[i].StartsWith($"P-{data}\\"))
                        {
                            p_group.Add(raw[i]);
                        }
                    }
                    File.AppendAllLines($"output{p_location[data]}.txt", p_group);
                    p_group.Clear();
                }

                Dictionary<string, int> measurement_names = new Dictionary<string, int>();
                // Appends the D-entries
                foreach (int data in d_location.Keys)
                {
                    for (int i = 0; i < raw.Length; i++)
                    {
                        if (raw[i].StartsWith($"D-{data}\\"))
                        {
                            d_group.Add(raw[i]);
                        }
                        if (raw[i].Contains("\\MN-") && !measurement_names.ContainsKey(raw[i].Substring(raw[i].LastIndexOf(":") + 1).Replace(";", "")))
                        {
                            measurement_names.Add(raw[i].Substring(raw[i].LastIndexOf(":") + 1).Replace(";", ""), d_location[data]);
                        }
                    }
                    File.AppendAllLines($"output{d_location[data]}.txt", d_group);
                    d_group.Clear();
                }

                // Find the C-Entries based on Measurement Number
                int c_id = 0;
                Dictionary<int, int> c_location = new Dictionary<int, int>();

                foreach (string data in measurement_names.Keys)
                {
                    for (int i = 0; i < raw.Length; i++)
                    {
                        if (raw[i].StartsWith("C-") && raw[i].Contains("\\DCN:" + data))
                        {
                            var start = raw[i].IndexOf("-") + 1;
                            c_id = Int32.Parse(raw[i].Substring(start, raw[i].IndexOf("\\") - start));
                            c_location.Add(c_id, measurement_names[data]);
                        }
                    }
                }

                // Append the C-entries at the end of the output file 
                List<string> c_group = new List<string>();
                foreach (int data in c_location.Keys)
                {
                    for (int i = 0; i < raw.Length; i++)
                    {
                        if (raw[i].StartsWith($"C-{data}\\"))
                        {
                            c_group.Add(raw[i]);
                        }
                    }
                    File.AppendAllLines($"output{c_location[data]}.txt", c_group);
                    c_group.Clear();
                }

                MessageBox.Show("Split Complete!");



            }
            else if (file_box.Text == "")
            {
                MessageBox.Show("Please enter the specified file");
            }
            else
            {
                MessageBox.Show("The file is not a Chapter 10 File");
                file_box.Clear();
                outputBox.Clear();
            }
        }

        private void mergeBtnClick(object sender, EventArgs e)
        {
            merge(false);
        }

        private void merge(Boolean flag)
        {
            // Checks to see if either file inputted is a chapter 10 file
            if (file_1_box.Text.Contains(".ch10") && file_2_box.Text.Contains(".ch10"))
            {
                if (File.Exists("merged.txt"))
                {
                    File.Delete("merged.txt");
                }
                /*System.IO.File.WriteAllText("file1.txt", string.Empty);
                System.IO.File.WriteAllText("file2.txt", string.Empty);
                // Initialize arrays and variables 
                create_output(" file1.txt", " -r", file_1_box);
                Thread.Sleep(3000);
                create_output(" file2.txt", " -r", file_2_box);
                Thread.Sleep(3000);*/
                string[] file1 = chapter10_parser(file_1_box);
                string[] file2 = chapter10_parser(file_2_box);

                int highest_r = 0;
                int highest_b = 0;
                int highest_m = 0;
                int highest_d = 0;
                int highest_p = 0;
                int highest_c = 0;

                // Find DLNs in the File
                HashSet<String> DLN_set = new HashSet<String>();

                for (int i = 0; i < file1.Length; i++)
                {
                    var start1 = file1[i].IndexOf("-") + 1;
                    if (file1[i].StartsWith("D-") && file1[i].Contains("MLN"))
                    {
                        DLN_set.Add(file1[i].Substring(file1[i].LastIndexOf(":") + 1).Replace(";", ""));
                    }
                }



                // Finds Linkage between DLN and MN
                Dictionary<int, String> mn_dict = new Dictionary<int, String>();
                foreach (string DLN_name in DLN_set)
                {
                    for (int i = 0; i < file1.Length; i++)
                    {
                        if (file1[i].StartsWith("D-") && file1[i].Contains(DLN_name) &&
                            !mn_dict.ContainsValue(file1[i].Substring(file1[i].LastIndexOf(":") + 1).Replace(";", "")))
                        {
                            var start = file1[i].IndexOf("-") + 1;
                            String dcn_name = file1[i].Substring(file1[i].LastIndexOf(":") + 1).Replace(";", "");
                            int dcn_id = Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start));
                            mn_dict.Add(dcn_id, dcn_name);
                        }
                    }
                }



                // Finds MN for D-Group
                Dictionary<String, String> mn = new Dictionary<String, String>();
                foreach (var kvp in mn_dict)
                {
                    for (int i = 0; i < file1.Length; i++)
                    {
                        var start = file1[i].IndexOf("-") + 1;
                        if (file1[i].StartsWith("D-") && file1[i].Contains("MN-") &&
                            !mn.ContainsKey(file1[i].Substring(file1[i].LastIndexOf(":") + 1).Replace(";", "")) &&
                            Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start)) == kvp.Key)
                        {
                            mn.Add(file1[i].Substring(file1[i].LastIndexOf(":") + 1).Replace(";", ""), kvp.Value);
                        }
                    }
                }

                //Find C-ID Associated with Each MN
                Dictionary<int, KeyValuePair<String, String>> mn_cid = new Dictionary<int, KeyValuePair<String, String>>();
                foreach (var mn_key in mn)
                {
                    for (int i = 0; i < file1.Length; i++)
                    {
                        var start = file1[i].IndexOf("-") + 1;
                        if (file1[i].StartsWith("C-") && file1[i].Contains(mn_key.Key))
                        {
                            mn_cid.Add(Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start)), mn_key);
                        }
                    }
                }




                // Sets up the contents from file 1, as well as keep track of the highest group streams
                for (int i = 0; i < file1.Length; i++)
                {
                    if (file1[i].StartsWith("G\\") && !file1[i].Contains("="))
                    {
                        outputBox.Text += file1[i] + "\n";
                    }
                    else if (file1[i].StartsWith("R-") && file1[i].EndsWith(";") && file1[i].Contains(":") && file1[i].Contains("\\"))
                    {

                        var start = file1[i].IndexOf("-") + 1;
                        if (Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start)) >= highest_r)
                        {
                            highest_r = Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start));
                            outputBox.Text += file1[i] + "\n";
                        }
                    }
                    else if (file1[i].StartsWith("B-") && file1[i].EndsWith(";") && file1[i].Contains(":") && file1[i].Contains("\\"))
                    {
                        var start = file1[i].IndexOf("-") + 1;
                        if (Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start)) >= highest_b)
                        {
                            highest_b = Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start));
                            outputBox.Text += file1[i] + "\n";
                        }
                    }
                    else if (file1[i].StartsWith("M-") && file1[i].EndsWith(";") && file1[i].Contains(":") && file1[i].Contains("\\"))
                    {
                        var start = file1[i].IndexOf("-") + 1;
                        if (Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start)) >= highest_m)
                        {
                            highest_m = Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start));
                            outputBox.Text += file1[i] + "\n";
                        }
                    }
                    else if (file1[i].StartsWith("D-") && file1[i].EndsWith(";") && file1[i].Contains(":") && file1[i].Contains("\\"))
                    {
                        var start = file1[i].IndexOf("-") + 1;
                        if (Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start)) >= highest_d)
                        {
                            highest_d = Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start));
                            outputBox.Text += file1[i] + "\n";
                        }
                    }
                    else if (file1[i].StartsWith("P-") && file1[i].EndsWith(";") && file1[i].Contains(":") && file1[i].Contains("\\"))
                    {
                        var start = file1[i].IndexOf("-") + 1;
                        if (Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start)) >= highest_p)
                        {
                            highest_p = Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start));
                            outputBox.Text += file1[i] + "\n";
                        }
                    }
                    else if (file1[i].StartsWith("C-") && file1[i].EndsWith(";") && file1[i].Contains(":") && file1[i].Contains("\\"))
                    {

                        var start = file1[i].IndexOf("-") + 1;
                        if (Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start)) >= highest_c)
                        {
                            highest_c = Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start));
                        }
                        int c_group_id = Int32.Parse(file1[i].Substring(start, file1[i].IndexOf("\\") - start));
                        if (flag)
                        {
                            int colon = file1[i].LastIndexOf(":");
                            outputBox.Text += file1[i].Substring(0, colon + 1) + mn_cid[c_group_id].Value + "A " +
                                file1[i].Substring(colon + 1) + "\n";
                        }
                        else
                        {
                            outputBox.Text += file1[i] + "\n";
                        }

                    }
                    else
                    {
                        continue;
                    }
                }


                // Process the second file, and updates the group streams based on the highest group streams
                int current_r = 0;
                int current_b = 0;
                int current_m = 0;
                int current_d = 0;
                int current_p = 0;
                int current_c = 0;

                int r_id = 0;
                int b_id = 0;
                int m_id = 0;
                int d_id = 0;
                int p_id = 0;
                int c_id = 0;
                for (int i = 0; i < file2.Length; i++)
                {
                    if (file2[i].StartsWith("R-") && file2[i].EndsWith(";") && file2[i].Contains(":") && file2[i].Contains("\\"))
                    {
                        var start = file2[i].IndexOf("-") + 1;
                        if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) >= current_r)
                        {
                            current_r = Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start));
                            string metadata = file2[i].Substring(file2[i].IndexOf("\\"));
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) > current_r)
                            {
                                highest_r++;
                            }
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) == 0)
                            {
                                r_id++;
                            }
                            outputBox.Text += "R-" + (current_r + highest_r + r_id).ToString() + metadata + "\n";
                        }
                    }
                    else if (file2[i].StartsWith("B-") && file2[i].EndsWith(";") && file2[i].Contains(":") && file2[i].Contains("\\"))
                    {
                        var start = file2[i].IndexOf("-") + 1;
                        if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) >= current_b)
                        {
                            current_b = Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start));
                            string metadata = file2[i].Substring(file2[i].IndexOf("\\"));
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) > current_b)
                            {
                                highest_b++;
                            }
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) == 0)
                            {
                                b_id++;
                            }
                            outputBox.Text += "B-" + (current_b + highest_b + b_id).ToString() + metadata + "\n";
                        }
                    }
                    else if (file2[i].StartsWith("M-") && file2[i].EndsWith(";") && file2[i].Contains(":") && file2[i].Contains("\\"))
                    {
                        var start = file2[i].IndexOf("-") + 1;

                        if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) >= current_m)
                        {
                            current_m = Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start));
                            string metadata = file2[i].Substring(file2[i].IndexOf("\\"));
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) > current_m)
                            {
                                highest_m++;
                            }
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) == 0 && m_id == 0)
                            {
                                m_id++;
                            }
                            outputBox.Text += "M-" + (current_m + highest_m + m_id).ToString() + metadata + "\n";
                        }
                    }
                    else if (file2[i].StartsWith("D-") && file2[i].EndsWith(";") && file2[i].Contains(":") && file2[i].Contains("\\"))
                    {
                        var start = file2[i].IndexOf("-") + 1;
                        if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) >= current_d)
                        {
                            current_d = Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start));
                            string metadata = file2[i].Substring(file2[i].IndexOf("\\"));
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) > current_d)
                            {
                                highest_d++;
                            }
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) == 0 && d_id == 0)
                            {
                                d_id++;
                            }
                            outputBox.Text += "D-" + (current_d + highest_d + d_id).ToString() + metadata + "\n";
                        }
                    }
                    else if (file2[i].StartsWith("P-") && file2[i].EndsWith(";") && file2[i].Contains(":") && file2[i].Contains("\\"))
                    {
                        var start = file2[i].IndexOf("-") + 1;
                        if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) >= current_p)
                        {
                            current_p = Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start));
                            string metadata = file2[i].Substring(file2[i].IndexOf("\\"));
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) > current_p)
                            {
                                highest_p++;
                            }
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) == 0 && p_id == 0)
                            {
                                p_id++;
                            }
                            outputBox.Text += "P-" + (current_p + highest_p + p_id).ToString() + metadata + "\n";
                        }
                    }
                    else if (file2[i].StartsWith("C-") && file2[i].EndsWith(";") && file2[i].Contains(":") && file2[i].Contains("\\"))
                    {
                        var start = file2[i].IndexOf("-") + 1;
                        if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) >= current_c)
                        {
                            current_c = Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start));
                            string metadata = file2[i].Substring(file2[i].IndexOf("\\"));
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) > current_c)
                            {
                                highest_c++;
                            }
                            if (Int32.Parse(file2[i].Substring(start, file2[i].IndexOf("\\") - start)) == 0 && c_id == 0)
                            {
                                c_id++;
                            }
                            if (flag)
                            {
                                int colon = file1[i].LastIndexOf(":");
                                int dash = file1[i].IndexOf("\\");
                                outputBox.Text += "C-" + (current_c + highest_c + c_id).ToString() +
                                    file1[i].Substring(dash, colon - dash + 1) + mn_cid[current_c].Value + "B " +
                                    file1[i].Substring(colon + 1) + "\n";
                            }
                            else
                            {
                                outputBox.Text += "C-" + (current_c + highest_c + c_id).ToString() + metadata + "\n";
                            }
                        }


                    }
                }
                File.AppendAllText("merged.txt", outputBox.Text);

                MessageBox.Show("Merge Complete!");


            }
            else if (file_1_box.Text == "" || file_2_box.Text == "")
            {
                MessageBox.Show("Please enter the specified file to both inputs");
            }
            else
            {
                MessageBox.Show("One of the files is not a Chapter 10 File");
                file_1_box.Clear();
                file_2_box.Clear();
            }
        }

        // Process the contents of a file and outputs it in a textbox
        private void create_output(string file, string param, TextBoxBase textbox)
        {
            string filename = textbox.Text;

            if (filename.Contains(".ch10"))
            {
                var proc = new Process();
                ProcessStartInfo psi = new ProcessStartInfo();

                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.UseShellExecute = false;

                proc.StartInfo.Arguments = filename + file + param;
                proc.StartInfo.FileName = "idmptmat.exe";
                proc.Start();
                proc.WaitForExit();

            }
        }
        // Opens a file dialog for file #1 in the merge subsection
        private void input_1Click(object sender, EventArgs e)
        {
            string file = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                output_file_path(sender, e, file, file_1_box);
            }
        }

        // Opens a file dialog for file #2 in the merge subsection
        private void input_2Click(object sender, EventArgs e)
        {
            string file = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                output_file_path(sender, e, file, file_2_box);
            }
        }

        // Merge Files that are the Same, 
        private void merge2_Click(object sender, EventArgs e)
        {
            merge(true);
        }

        private string[] chapter10_parser(TextBoxBase textbox)
        {
            string filename = textbox.Text;
            if (filename.Contains(".ch10"))
            {
                string[] stringArray = File.ReadAllLines(filename);
                List<String> list = new List<String>();
                for (int i = 0; i < stringArray.Length; i++)
                {
                    if (stringArray[i].EndsWith(";") && (stringArray[i].StartsWith("G\\")
                        || stringArray[i].StartsWith("R-") || stringArray[i].StartsWith("B-")
                        || stringArray[i].StartsWith("M-") || stringArray[i].StartsWith("P-")
                        || stringArray[i].StartsWith("D-") || stringArray[i].StartsWith("C-")))
                    {
                        list.Add(stringArray[i]);
                    }
                }

                return list.ToArray();
            }

            return new string[] { };
        }
    }
}

