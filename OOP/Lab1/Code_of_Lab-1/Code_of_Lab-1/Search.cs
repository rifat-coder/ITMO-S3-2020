using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Code_of_Lab_1
{
    public class Search
    {
        public string file_name;
        private bool section_found = false;
        private string P_Name = "";
        private string P_Value = "";
        private List<string> sections_names = new List<string>();
        private string section_name = "";
        string pattern_for_section = @"^\[.*\]";
        string pattern_empty_line = @"^\s*$";
        string pattern_parametrs = @"^[A-Za-z0-9_]+\s=\s[A-Za-z0-9_\/.]+";
        private Dictionary<string, Dictionary<string, string>> all_parametrs = new Dictionary<string, Dictionary<string, string>>();
        public Search(string _file_name)
        {
            file_name = _file_name;
        }
        private bool check_section(string line)
        {
            if (Regex.IsMatch(line, pattern_for_section))
            {
                section_found = true;
                Regex regex = new Regex(pattern_for_section);
                MatchCollection matches = regex.Matches(line);
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                        sections_names.Add(match.Value);
                    section_name = sections_names[0];
                    sections_names.Clear();
                }
                return true;
            }
            return false;
        }
        private bool line_empty(string line)
        {
            if (Regex.IsMatch(line, pattern_empty_line))
            {   
                return true;
            }
            return false;
        }
        private bool parse_parametrs(string line)
        {
            if (Regex.IsMatch(line, pattern_parametrs))
            {
                line = line.Replace("=", "");
                string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                P_Name = words[0];
                P_Value = words[1];
                return true;
            }
            return false;
        }
        private void adding_par(string section_name, Parameters p)
        {
            if (!all_parametrs.ContainsKey(section_name))
            {
                all_parametrs.Add(section_name, new Dictionary<string, string> { [p.name] = p.get_value() });
            }
            else
            {
                all_parametrs[section_name].Add(p.name, p.get_value());
            }
        }
        public void read_file()
        {
            try
            {
                using (StreamReader sr = new StreamReader(file_name, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!(check_section(line) || line_empty(line)))
                        {
                            if (section_found && (parse_parametrs(line)))
                            {
                                Parameters parameter = new Parameters(P_Name, P_Value);
                                adding_par(section_name, parameter);
                            }
                            else
                            {
                                throw new Local_Exception($"Invalid file format: {line} -- is incorrect. Format should be \n[section name] \nname = value");
                            }
                        }
                        
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"[DATA FILE MISSING] {e}");
                throw new FileNotFoundException(@"[file.ini not found", e);
            }

        }
        public dynamic finder(string section_name, string parametr)
        {
            if (!all_parametrs.ContainsKey(section_name))
            {
                throw new Local_Exception($"Not found section {section_name} in ini file.");
            }
            if (!all_parametrs[section_name].ContainsKey(parametr))
            {
                throw new Local_Exception($"Not found parametr {parametr} in the section {section_name}.");
            }
            if (Int32.TryParse(all_parametrs[section_name][parametr], out int intval))
            {
                return intval;
            }
            else if (Double.TryParse(all_parametrs[section_name][parametr], out double doubletval))
            {
                return doubletval;
            }
            else
            {
                return all_parametrs[section_name][parametr];
            }
            //return all_parametrs[section_name][parametr];
        }
    }
}
