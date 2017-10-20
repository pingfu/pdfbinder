/*
 * Copyright 2009-2011 Joern Schou-Rode
 * 
 * This file is part of PDFBinder.
 *
 * PDFBinder is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * PDFBinder is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with PDFBinder.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Windows.Forms;

namespace PDFBinder
{
    static class Program
    {
        public static MainForm MainForm { get; private set; }

        /// <summary>
        /// https://github.com/schourode/pdfbinder
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm = new MainForm();

            var fileNames = new string[args.Length];
            Array.Copy(args, fileNames, args.Length);
            Array.Sort(fileNames);

            var loader = new ProcessLinker();
            loader.SendFileList(fileNames);

            if (loader.IsServer || args.Length == 0)
            {
                Application.Run(MainForm);
            }
        }
    }
}
