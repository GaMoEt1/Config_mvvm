 class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;// kiểu delegte với tham sô T kiểu trả về bool
        private readonly Action<T> _execute;// kiểu trả về void 

        public RelayCommand(Predicate<T> canExecute, Action<T> execute)// hàm cho phép thực hiện lệnh 
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)// cho phép thực thi hay không 
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public void Execute(object parameter)// thực thi các hoạt động
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }