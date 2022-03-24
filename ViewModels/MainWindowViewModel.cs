using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using LabMileshko6.Models;
using System.Collections.ObjectModel;

namespace LabMileshko6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public List<Task> ItemsAll { get; set; }
        public MainWindowViewModel()
        {
            Content = fv = new ToDoViewModel(BuildAllNotes());


            AddButton = ReactiveCommand.Create<Unit, Unit>(
                (unit) =>
                {
                    var newItem = new Task("", "", fv.Currentdate);
                    var sv = new TaskViewModel(newItem);
                    Observable.Merge(
                sv.OKButton,
                sv.CancelButton.Select(_ => Unit.Default))
                .Take(1)
                .Subscribe(unit =>
                {
                    if (newItem.Name != "")
                        ItemsAll.Add(newItem);
                    fv.changeItems();
                    Content = fv;
                });
                    Content = sv;
                    return Unit.Default;
                });

            OpenButton = ReactiveCommand.Create<Task, Unit>(
                (item) =>
                {
                    var sv = new TaskViewModel(item);
                    Observable.Merge(
                sv.OKButton,
                sv.CancelButton.Select(_ => Unit.Default))
                .Take(1)
                .Subscribe(unit =>
                {
                    fv.changeItems();
                    Content = fv;
                });
                    Content = sv;
                    return Unit.Default;
                });

            DeleteButton = ReactiveCommand.Create<Task, Unit>((item) =>
            {
                ItemsAll.Remove(item);
                fv.changeItems();
                return Unit.Default;
            });
            ItemsAll = BuildAllNotes();
            Content = fv = new ToDoViewModel(ItemsAll);


        }

        ViewModelBase content;
        public ViewModelBase Content
        {
            set => this.RaiseAndSetIfChanged(ref content, value);
            get => content;
        }

        public ToDoViewModel fv
        {
            get;
        }
        public ReactiveCommand<Unit, Unit> AddButton { get; }
        public ReactiveCommand<Task, Unit> OpenButton { get; }
        public ReactiveCommand<Task, Unit> DeleteButton { get; }
        private List<Task> BuildAllNotes()
        {
            return new List<Task>
            {
                new Task("Сделать лабу №6", "Задача выполнена", DateTime.Today),
                new Task("Сделать лабу №7", "Задача не будет выполнена", DateTime.Today),
            };
        }

    }
}