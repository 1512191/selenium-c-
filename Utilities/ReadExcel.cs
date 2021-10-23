using Microsoft.Extensions.Configuration;
using NUnitTestProject1.Variables;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NUnitTestProject1.Utilities
{
	class ReadExcel
	{
		public static ConfigSetting config;
		static string configSettingPath = System.IO.Directory.GetParent(@"../../../").FullName
			+ System.IO.Path.DirectorySeparatorChar + "Resources/config.json";
		public static void readJsonFile()
		{
			ConfigurationBuilder builder = new ConfigurationBuilder();
			config = new ConfigSetting();
		
			Console.WriteLine(configSettingPath);
			builder.AddJsonFile(configSettingPath);
			IConfigurationRoot configurationRoot = builder.Build();
			configurationRoot.Bind(config);
		}

		private string path = null;
		private string testcase_name = null;
		private string sheet_name = null;
		public DataTable readExcelFile(string path, string testcase_no, string sheet_name)
		{


			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(path)))
			{
				try
				{
					ExcelWorksheet worksheet = package.Workbook.Worksheets[sheet_name];
					DataTable table = new DataTable();
					if (worksheet.Dimension == null)
					{
						return table;
					}
					int start_row = worksheet.Dimension.Start.Row;
					int end_row = worksheet.Dimension.End.Row;
					string cellRange = start_row.ToString() + ":" + end_row.ToString();
					var searchCell = from cell in worksheet.Cells[cellRange]
									 where cell.Value.ToString() == testcase_no
									 select cell.Start.Row;
					int row = searchCell.First();
					foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
					{
						string column = firstRowCell.Text.Trim();
						Console.WriteLine(column);
						table.Columns.Add(column);
					}
					DataRow dataRow = table.NewRow();
					foreach (var cell in worksheet.Cells[row, 1, row, worksheet.Dimension.End.Column])
					{
						dataRow[cell.Start.Column - 1] = cell.Text;
					}
					table.Rows.Add(dataRow);
					Console.WriteLine(table.Rows[0].ItemArray[0].ToString());
					return table;
				}
				catch (Exception e)
				{
					throw new ArgumentException("Can not open file {0}", path);

				}









			}
		}

	}
}
