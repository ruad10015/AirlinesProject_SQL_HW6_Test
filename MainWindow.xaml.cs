using AirlinesProject_SQL_HW6.DataAccess;
using AirlinesProject_SQL_HW6.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirlinesProject_SQL_HW6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyContext _context = new MyContext();
        public ObservableCollection<Airplane> Airplanes { get; set; } = new ObservableCollection<Airplane>();
        public ObservableCollection<Cities> Cities { get; set; } = new ObservableCollection<Cities>();
        public ObservableCollection<Pilot> Pilots { get; set; } = new ObservableCollection<Pilot>();
        public ObservableCollection<Schedule> Schedules { get; set; } = new ObservableCollection<Schedule>();
        public ObservableCollection<Ticket> Tickets { get; set; } = new ObservableCollection<Ticket>();

        public MainWindow()
        {
            InitializeComponent();

            //_context.Database.CreateIfNotExists();

            this.DataContext = this;

            citieInfo.SelectedIndex = 0;
            airplanesInfo.SelectedIndex = 0;
            scheduleInfo.SelectedIndex = 0;


            LoadAirplane();
            LoadCitie();
            LoadPilot();
            LoadSchedule();
            LoadTicket();
        }



        private void AddTicket()
        {
            var ticket_List = new List<Ticket>
            {
                new Ticket { TicketId = 1, ScheduleId = 31, PassengerName = "Ruad Dunyamaliyev", SeatNumber = "A111", ClassType = "Economy" },
                new Ticket { TicketId = 2, ScheduleId = 32, PassengerName = "Seid Mammedov", SeatNumber = "B222", ClassType = "Business" },
                new Ticket { TicketId = 3, ScheduleId = 33, PassengerName = "Eli Eliyev", SeatNumber = "C333", ClassType = "Premium" },
                new Ticket { TicketId = 4, ScheduleId = 34, PassengerName = "Elvin Camalzade", SeatNumber = "D444", ClassType = "Economy" },
            };

            using (var context = new MyContext())
            {
            _context.Tickets.AddRange(ticket_List);
            _context.SaveChanges();
            }

        }
        private void LoadTicket()
        {
            if (_context.Tickets.Count() == 0)
            {
                AddTicket();
            }

            foreach (var ticket in _context.Tickets)
            {
                Tickets.Add(ticket);
            }
        }



        private void AddPilot()
        {
            var pilots_List = new List<Pilot>
            {
                new Pilot { PilotId = 1, Name = "Cristiano Ronaldo", LicenseNumber = "ABC738" },
                new Pilot { PilotId = 2, Name = "ELionel Messi", LicenseNumber = "XYZ583" },
                new Pilot { PilotId = 3, Name = "Neymar JR", LicenseNumber = "DEF151" },
                new Pilot { PilotId = 4, Name = "MO-Salah", LicenseNumber = "GHI767" },
            };

            using (var context = new MyContext())
            {

            _context.Pilots.AddRange(pilots_List);
            _context.SaveChanges();

            }
        }
        private void LoadPilot()
        {
            if (_context.Pilots.Count() == 0)
            {
                AddPilot();
            }

            foreach (var pilot in _context.Pilots)
            {
                Pilots.Add(pilot);
            }
        }



        private void AddCities()
        {
            var cities_List = new List<Cities>
            {
                new Cities { CityId = 1, CityName = "Lisbon", Country = "Portugal" },
                new Cities { CityId = 2, CityName = "London", Country = "UK" },
                new Cities { CityId = 3, CityName = "Tokyo", Country = "Japan" },
                new Cities { CityId = 4, CityName = "Paris", Country = "France" },
                new Cities { CityId = 5, CityName = "Dubai", Country = "UAE" },
                new Cities { CityId = 6, CityName = "Los Angeles", Country = "USA" },
                new Cities { CityId = 7, CityName = "Sydney", Country = "Australia" },
            };
            using (var context = new MyContext())
            {

            _context.Cities.AddRange(cities_List);
            _context.SaveChanges();

            }
        }
        private void LoadCitie()
        {
            if (_context.Cities.Count() == 0)
            {
                AddCities();
            }

            foreach (var citie in _context.Cities)
            {
                Cities.Add(citie);
            }
        }



        private void AddAirplane()
        {
            var airplanes_List = new List<Airplane>
            {
                new Airplane { PlaneId = 13, Model = "Boeing 747", Capacity = 400 },
                new Airplane { PlaneId = 14, Model = "Airbus A380", Capacity = 550 },
                new Airplane { PlaneId = 15, Model = "Boeing 777", Capacity = 350 },
                new Airplane { PlaneId = 16, Model = "Boeing 737", Capacity = 200 },
            };

            using (var context = new MyContext())
            {

                _context.Airplanes.AddRange(airplanes_List);
                _context.SaveChanges();

            }

        }
        private void LoadAirplane()
        {
            if (_context.Airplanes.Count() == 0)
            {
                AddAirplane();
            }

            foreach (var airplane in _context.Airplanes)
            {
                Airplanes.Add(airplane);
            }
        }




        private void AddSchedule()
        {
            var schedules_List = new List<Schedule>
            {
                new Schedule { ScheduleId = 1, FlightNumber = "AA111", DepartureCityID = 1, ArrivalCityID = 2, DepartureTime = DateTime.Parse("2024-02-12 08:00:00"), ArrivalTime = DateTime.Parse("2024-02-12 11:00:00"), PlaneId = 13, PilotId = 1 },
                new Schedule { ScheduleId = 2, FlightNumber = "BA222", DepartureCityID = 2, ArrivalCityID = 1, DepartureTime = DateTime.Parse("2024-02-12 10:00:00"), ArrivalTime = DateTime.Parse("2024-02-12 13:00:00"), PlaneId = 14, PilotId = 2 },
                new Schedule { ScheduleId = 3, FlightNumber = "JL333", DepartureCityID = 3, ArrivalCityID = 4, DepartureTime = DateTime.Parse("2024-02-13 12:00:00"), ArrivalTime = DateTime.Parse("2024-02-13 18:00:00"), PlaneId = 15, PilotId = 3 },
                new Schedule { ScheduleId = 4, FlightNumber = "DL444", DepartureCityID = 6, ArrivalCityID = 1, DepartureTime = DateTime.Parse("2024-02-13 14:00:00"), ArrivalTime = DateTime.Parse("2024-02-13 17:00:00"), PlaneId = 16, PilotId = 4 },
            };

            using (var context = new MyContext())
            {

                _context.Schedules.AddRange(schedules_List);
                _context.SaveChanges();

            }
        }
        private void LoadSchedule()
        {
            if (_context.Schedules.Count() == 0)
            {
                AddSchedule();
            }

            foreach (var schedule in _context.Schedules)
            {
                Schedules.Add(schedule);
            }
        }

        private void citieInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowTicketInfo();
        }

        private void airplanesInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowTicketInfo();
        }

        private void scheduleInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowTicketInfo();
        }
        private void ShowTicketInfo()
        {
            var selectedCitie = citieInfo.SelectedItem as Cities;
            var selectedAirplane = airplanesInfo.SelectedItem as Airplane;
            var selectedSchedule = scheduleInfo.SelectedItem as Schedule;


            if (selectedSchedule != null)
            {
                ticketId.Text = "Plane Id : " + selectedSchedule.PlaneId;
                scheduleId.Text = "Pilot Id : " + selectedSchedule.PilotId;
                departureTime.Text = "Flight : " + selectedSchedule.DepartureTime;
                seatNumber.Text = "";
                classType.Text = "";
            }
        }
    }
}