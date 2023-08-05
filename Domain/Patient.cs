namespace Domain
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }

        public List<Injury> Injuries { get; set; } = new();

       

        public Patient(string name, string? address, int age)
        {
            

            Name = name;
            Address = address;
            Age = age;
        }
        public void update(string name, string address, int age)
        {
            
            this.Name = name;
            this.Address = address;
            this.Age = age;
        }
        public void RemoveI(Injury injurys) => Injuries.Remove(injurys);

        public void AddI(Injury injurys) => Injuries.Add(injurys);

        public void AddI(List<Injury> injurys) => Injuries.AddRange(injurys);

        public void UpdateI(List<Injury> injurys)
        {
            Injuries.AddRange(injurys?.Where(newItem => !injurys.Contains(newItem)) ?? Enumerable.Empty<Injury>());
            Injuries.RemoveAll(oldItem
                   => !injurys?.Contains(oldItem) ?? true);
        }

    }
}