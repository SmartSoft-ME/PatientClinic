﻿namespace Domain
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public List<Injury> Injuries { get; set; } = new();

    
        public Patient() { }
        public Patient(string name, string? address, int age)
        {
            Name= name;
            Address= address;
            Age= age;
        }
        public Patient(string name, string? address, int age,List<Injury> injury)
        {
            Injuries = injury;
            Name = name;
            Address = address;
            Age = age;
        }
        public void Update(string name, string address, int age)
        {
            
            this.Name = name;
            this.Address = address;
            this.Age = age;
        }
        public void RemoveInjury(Injury injuries) => Injuries.Remove(injuries);

        public void AddInjury(Injury injury)
        {
            Injuries.Add(injury);
        }
        public void AddInjuries(List<Injury> injuries) => Injuries.AddRange(injuries);

        public void UpdateI(List<Injury> injuries)
        {
            Injuries.AddRange(injuries?.Where(newItem => !injuries.Contains(newItem)) ?? Enumerable.Empty<Injury>());
            Injuries.RemoveAll(oldItem
                   => !injuries?.Contains(oldItem) ?? true);
        }

    }
}