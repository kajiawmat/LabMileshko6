using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMileshko6.Models
{
    public class Task
    {
        public Task(string name, string text, DateTimeOffset date)
        {
            Name = name;
            Text = text;
            Date = date;
        }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
