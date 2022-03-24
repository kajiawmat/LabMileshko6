using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;
using System.Reactive.Linq;
using LabMileshko6.Models;
using System.Collections.ObjectModel;

namespace LabMileshko6.ViewModels
{
    public class ToDoViewModel : ViewModelBase
    {
        public ToDoViewModel(List<Models.Task> ItemsList)
        {
            ItemsAll = ItemsList;
            Currentdate = DateTime.Today;
            changeItems();
        }

        DateTimeOffset currentdate;
        public DateTimeOffset Currentdate
        {
            get
            {
                return currentdate;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref currentdate, value);
                changeItems();
            }
        }
        public void changeItems()
        {
            List<Models.Task> Items = new List<Models.Task>();
            foreach (var item in ItemsAll)
            {
                if (item.Date.Equals(Currentdate)) Items.Add(item);
            }
            ItemsCurrent = Items;
        }

        public List<Models.Task> ItemsAll { get; set; }
        public List<Models.Task> itemscurrent;

        public List<Models.Task> ItemsCurrent
        {
            get
            {
                return itemscurrent;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref itemscurrent, value);
            }
        }

    }






}
