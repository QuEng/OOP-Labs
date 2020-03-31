using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows;

namespace Serialization {
    
    public partial class MainWindow : Window {
        List<Student> _students = new List<Student>();
        List<Student> _deserializeStudents = new List<Student>();
        private int _currentStudentIndex = 0;

        public MainWindow() {
            InitializeComponent();
        }

        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxStudentName.Text)
                || string.IsNullOrWhiteSpace(TextBoxStudentAge.Text)
                || string.IsNullOrWhiteSpace(TextBoxStudentTicketDateOfIssue.Text)
                || string.IsNullOrWhiteSpace(TextBoxStudentTicketNumber.Text)
            ) {
                MessageBox.Show("Помилка! Перевірте введені дані");
            } else {
                var student = new Student(
                    TextBoxStudentName.Text,
                    TextBoxStudentAge.Text,
                    new Student.StudentTicket(TextBoxStudentTicketDateOfIssue.Text, TextBoxStudentTicketNumber.Text)
                );
                _students.Add(student);
                if (!ButtonSerializable.IsEnabled) ButtonSerializable.IsEnabled = true;

                ClearTextBoxes();
            }
        }

        private void ButtonSerializable_Click(object sender, RoutedEventArgs e) {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Student>));
            using (var fs = new FileStream("StudentInfo.json", FileMode.OpenOrCreate)) {
                jsonFormatter.WriteObject(fs, _students);
            }
            ButtonDeserializable.IsEnabled = true;
            ButtonSerializable.IsEnabled = false;
        }

        private void ButtonDeserializable_Click(object sender, RoutedEventArgs e) {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Student>));
            using (var fs = new FileStream("StudentInfo.json", FileMode.OpenOrCreate)) {
                _deserializeStudents = jsonFormatter.ReadObject(fs) as List<Student>;
            }
            ButtonDeserializable.IsEnabled = false;
            if (_deserializeStudents?.Count > 1)
                ButtonNextStudent.IsEnabled = true;

            FillGrid();
        }

        private void ButtonPrevStudent_Click(object sender, RoutedEventArgs e) {
            _currentStudentIndex--;
            if (_currentStudentIndex == 0) ButtonPrevStudent.IsEnabled = false;
            if (!ButtonNextStudent.IsEnabled) ButtonNextStudent.IsEnabled = true;

            FillGrid();
        }

        private void ButtonNextStudent_Click(object sender, RoutedEventArgs e)
        {
            _currentStudentIndex++;
            if (_currentStudentIndex + 1 == _deserializeStudents.Count) ButtonNextStudent.IsEnabled = false;
            if (!ButtonPrevStudent.IsEnabled) ButtonPrevStudent.IsEnabled = true;

            FillGrid();
        }

        private void FillGrid() {
            LabelStudentName.Content = $"Ім'я: {_deserializeStudents[_currentStudentIndex].Name}";
            LabelStudentAge.Content = $"Вік: {_deserializeStudents[_currentStudentIndex].Age}";
            LabelStudentTicketDateOfIssue.Content = $"Студак виданий: {_deserializeStudents[_currentStudentIndex].Ticket.DateOfIssue}";
            LabelStudentTicketNumber.Content = $"Номер студака: {_deserializeStudents[_currentStudentIndex].Ticket.Number}";
        }

        private void ClearTextBoxes()
        {
            TextBoxStudentName.Text = string.Empty;
            TextBoxStudentAge.Text = string.Empty;
            TextBoxStudentTicketDateOfIssue.Text = string.Empty;
            TextBoxStudentTicketNumber.Text = string.Empty;
        }
    }
}
