internal class Program
{
    public class Person
     {
        public static string Separator { get; set; } = "/";
        private static int count = 0;
        public static Person? CreateInstance(string data)
        {
            string[] arr = data.Split(Separator);
            if (arr.Length < 3) return null;
            if (byte.TryParse(arr[2], out byte age) == false) return null;
            Person newPer = new Person()
            {
                Name = arr[0].Trim(),
                Gender = arr[1].Trim(),
                Age = age,
            };
            return newPer;
        }
        public int No { get; init; } = 0;
        public virtual string Name { get; set; } = default!;
        public virtual string Gender { get; set; } = default!;
        public virtual byte Age { get; set; } = default;
        public virtual string Info => $"name:{Name}, gender:{Gender}, age:{Age}";
        public Person(string name = "", string gender = "", byte age = 0)
        {
            No = ++count;
            Name = name;
            Gender = gender;
            Age = age;
        }
    }
    public class PersonList
    {
        protected List<Person> _pers = new();
        public virtual bool Add(Person rect)
        {
            if (_pers.Any(x => x.No == rect.No)) return false;
            _pers.Add(rect);
            return true;
        }
        public virtual Person? Modify(int targetNo, string name, string gender, byte age)
        {
            var found = _pers.FirstOrDefault(x => x.No == targetNo);
            if (found != null)
            {
                found.Name = name;
                found.Gender = gender;
                found.Age = age;
            }
            return found;
        }
        public virtual Person? Remove(int targetNo)
        {
            var found = _pers.FirstOrDefault(x => x.No == targetNo);
            if (found != null)
            {
                if (_pers.Remove(found))
                    return found;
                else
                    return null;
            }
            return null;
        }
        public virtual bool Remove(Person per)
        {
            return _pers.Remove(per);
        }
        public virtual void Clear()
        {
            _pers.Clear();
        }
        public List<Person> People => _pers;
        public byte MaxAge => _pers.Max(x => x.Age);
        public int Count => _pers.Count;
    }
}