using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n--- Оберіть завдання (1-4) або 0 для виходу ---");
                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": RunTask1(); break;
                    case "2": RunTask2(); break;
                    case "3": RunTask3(); break;
                    case "4": RunTask4(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір."); break;
                }
            }
        }

        static void RunTask1()
        {
            Console.WriteLine("\n=== ЗАВДАННЯ 1: КЛАС TRIANGLE (МОДИФІКОВАНИЙ) ===");
            Triangle t1 = new Triangle(3, 4, 5, 1);
            Console.WriteLine($"Початковий: {t1}");

            t1++;
            Console.WriteLine($"Після t1++: {t1}");

            t1 = t1 * 2;
            Console.WriteLine($"Після t1 * 2: {t1}");

            Console.WriteLine($"Індекс [0] (сторона a): {t1[0]}");
            Console.WriteLine($"Індекс [3] (колір): {t1[3]}");

            if (t1) Console.WriteLine("Трикутник існує.");
            else Console.WriteLine("Трикутник не існує.");

            string strValue = (string)t1;
            Console.WriteLine($"Явне приведення до string: {strValue}");

            Triangle t2 = "6,8,10,2";
            Console.WriteLine($"Створення з рядка \"6,8,10,2\": {t2}");
        }

        static void RunTask2()
        {
            Console.WriteLine("\n=== ЗАВДАННЯ 2: КЛАС VECTORUINT ===");
            VectorUInt v1 = new VectorUInt(3, 5);
            VectorUInt v2 = new VectorUInt(3, 2);

            Console.Write("Вектор v1: "); v1.Print();
            Console.Write("Вектор v2: "); v2.Print();

            VectorUInt vSum = v1 + v2;
            Console.Write("v1 + v2: "); vSum.Print();

            VectorUInt vScalar = v1 * 3;
            Console.Write("v1 * 3: "); vScalar.Print();

            v1++;
            Console.Write("v1++: "); v1.Print();

            Console.WriteLine($"Кількість створених векторів: {VectorUInt.GetNumVec()}");
        }

        static void RunTask3()
        {
            Console.WriteLine("\n=== ЗАВДАННЯ 3: СТРУКТУРИ, КОРТЕЖІ, ЗАПИСИ ===");

            Console.WriteLine("--- 1. Варіант зі структурами ---");
            List<EmployeeStruct> structs = new List<EmployeeStruct>
            {
                new EmployeeStruct("Іванов І.І.", "Інженер", 1990, 25000),
                new EmployeeStruct("Петров П.П.", "Директор", 1985, 50000),
                new EmployeeStruct("Сидоров С.С.", "Робітник", 1993, 18000)
            };
            structs.RemoveAll(e => e.LastName == "Петров");
            if (structs.Count >= 1)
                structs.Insert(1, new EmployeeStruct("Новий Н.Н.", "Службовець", 1995, 20000));
            foreach (var e in structs) Console.WriteLine($"{e.FullName}, {e.Position}, {e.Salary}");

            Console.WriteLine("\n--- 2. Варіант з кортежами ---");
            List<(string FullName, string Position, int BirthYear, double Salary)> tuples = new List<(string, string, int, double)>
            {
                ("Іванов І.І.", "Інженер", 1990, 25000),
                ("Петров П.П.", "Директор", 1985, 50000),
                ("Сидоров С.С.", "Робітник", 1993, 18000)
            };
            tuples.RemoveAll(t => t.FullName.StartsWith("Петров"));
            if (tuples.Count >= 1)
                tuples.Insert(1, ("Новий Н.Н.", "Службовець", 1995, 20000));
            foreach (var t in tuples) Console.WriteLine($"{t.FullName}, {t.Position}, {t.Salary}");

            Console.WriteLine("\n--- 3. Варіант із записами (Records) ---");
            List<EmployeeRecord> records = new List<EmployeeRecord>
            {
                new EmployeeRecord("Іванов І.І.", "Інженер", 1990, 25000),
                new EmployeeRecord("Петров П.П.", "Директор", 1985, 50000),
                new EmployeeRecord("Сидоров С.С.", "Робітник", 1993, 18000)
            };
            records.RemoveAll(r => r.FullName.StartsWith("Петров"));
            if (records.Count >= 1)
                records.Insert(1, new EmployeeRecord("Новий Н.Н.", "Службовець", 1995, 20000));
            foreach (var r in records) Console.WriteLine(r);
        }

        static void RunTask4()
        {
            Console.WriteLine("\n=== ЗАВДАННЯ 4: КЛАС MATRIXUINT ===");
            MatrixUint m1 = new MatrixUint(2, 2, 5);
            MatrixUint m2 = new MatrixUint(2, 2, 2);

            Console.WriteLine("Матриця m1:"); m1.Print();
            Console.WriteLine("Матриця m2:"); m2.Print();

            MatrixUint mSum = m1 + m2;
            Console.WriteLine("m1 + m2:"); mSum.Print();

            m1[0, 1] = 10;
            Console.WriteLine("m1 після зміни m1[0,1] = 10:"); m1.Print();

            Console.WriteLine($"Наскрізний індекс m1[2] (ряд 1, кол 0): {m1[2]}");
        }
    }

    class Triangle
    {
        protected int a;
        protected int b;
        protected int c;
        protected int color;

        public Triangle(int a, int b, int c, int color)
        {
            this.a = a; this.b = b; this.c = c; this.color = color;
        }

        public int this[int index]
        {
            get
            {
                return index switch
                {
                    0 => a,
                    1 => b,
                    2 => c,
                    3 => color,
                    _ => throw new IndexOutOfRangeException("Помилка: невірний індекс трикутника.")
                };
            }
            set
            {
                switch (index)
                {
                    case 0: a = value; break;
                    case 1: b = value; break;
                    case 2: c = value; break;
                    case 3: color = value; break;
                    default: throw new IndexOutOfRangeException("Помилка: невірний індекс трикутника.");
                }
            }
        }

        public static Triangle operator ++(Triangle t)
        {
            return new Triangle(t.a + 1, t.b + 1, t.c + 1, t.color);
        }

        public static Triangle operator --(Triangle t)
        {
            return new Triangle(t.a - 1, t.b - 1, t.c - 1, t.color);
        }

        public static bool operator true(Triangle t)
        {
            return t.a > 0 && t.b > 0 && t.c > 0 && (t.a + t.b > t.c) && (t.a + t.c > t.b) && (t.b + t.c > t.a);
        }

        public static bool operator false(Triangle t)
        {
            return !(t.a > 0 && t.b > 0 && t.c > 0 && (t.a + t.b > t.c) && (t.a + t.c > t.b) && (t.b + t.c > t.a));
        }

        public static Triangle operator *(Triangle t, int scalar)
        {
            return new Triangle(t.a * scalar, t.b * scalar, t.c * scalar, t.color);
        }

        public static explicit operator string(Triangle t)
        {
            return $"{t.a},{t.b},{t.c},{t.color}";
        }

        public static implicit operator Triangle(string str)
        {
            string[] parts = str.Split(',');
            return new Triangle(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
        }

        public override string ToString()
        {
            return $"Сторони: a={a}, b={b}, c={c}; Колір: {color}";
        }
    }

    class VectorUInt
    {
        protected uint[] IntArray;
        protected uint size;
        protected int codeError;
        protected static uint num_vec = 0;

        public VectorUInt()
        {
            size = 1;
            IntArray = new uint[size];
            IntArray[0] = 0;
            codeError = 0;
            num_vec++;
        }

        public VectorUInt(uint size)
        {
            this.size = size;
            IntArray = new uint[size];
            codeError = 0;
            num_vec++;
        }

        public VectorUInt(uint size, uint initValue)
        {
            this.size = size;
            IntArray = new uint[size];
            for (uint i = 0; i < size; i++) IntArray[i] = initValue;
            codeError = 0;
            num_vec++;
        }

        ~VectorUInt()
        {
            Console.WriteLine("Об'єкт VectorUInt знищено.");
        }

        public void Input()
        {
            for (uint i = 0; i < size; i++)
            {
                Console.Write($"Array[{i}] = ");
                IntArray[i] = uint.Parse(Console.ReadLine());
            }
        }

        public void Print()
        {
            for (uint i = 0; i < size; i++) Console.Write($"{IntArray[i]} ");
            Console.WriteLine();
        }

        public static uint GetNumVec()
        {
            return num_vec;
        }

        public uint Size => size;

        public int CodeError
        {
            get => codeError;
            set => codeError = value;
        }

        public uint this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    codeError = -1;
                    return 0;
                }
                return IntArray[index];
            }
            set
            {
                if (index < 0 || index >= size) codeError = -1;
                else IntArray[index] = value;
            }
        }

        public static VectorUInt operator ++(VectorUInt v)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = v.IntArray[i] + 1;
            return res;
        }

        public static VectorUInt operator --(VectorUInt v)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = v.IntArray[i] - 1;
            return res;
        }

        public static bool operator true(VectorUInt v)
        {
            if (v.size == 0) return false;
            foreach (var val in v.IntArray) if (val == 0) return false;
            return true;
        }

        public static bool operator false(VectorUInt v)
        {
            if (v.size == 0) return true;
            foreach (var val in v.IntArray) if (val == 0) return true;
            return false;
        }

        public static bool operator !(VectorUInt v)
        {
            return v.size == 0;
        }

        public static VectorUInt operator ~(VectorUInt v)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = ~v.IntArray[i];
            return res;
        }

        private static VectorUInt GetLarger(VectorUInt a, VectorUInt b, out uint minSize)
        {
            minSize = Math.Min(a.size, b.size);
            return a.size >= b.size ? a : b;
        }

        public static VectorUInt operator +(VectorUInt a, VectorUInt b)
        {
            VectorUInt larger = GetLarger(a, b, out uint min);
            VectorUInt res = new VectorUInt(larger.size);
            for (uint i = 0; i < larger.size; i++) res.IntArray[i] = larger.IntArray[i];
            for (uint i = 0; i < min; i++) res.IntArray[i] = a.IntArray[i] + b.IntArray[i];
            return res;
        }

        public static VectorUInt operator +(VectorUInt v, int scalar)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = (uint)(v.IntArray[i] + scalar);
            return res;
        }

        public static VectorUInt operator -(VectorUInt a, VectorUInt b)
        {
            VectorUInt larger = GetLarger(a, b, out uint min);
            VectorUInt res = new VectorUInt(larger.size);
            for (uint i = 0; i < larger.size; i++) res.IntArray[i] = larger.IntArray[i];
            for (uint i = 0; i < min; i++) res.IntArray[i] = a.IntArray[i] - b.IntArray[i];
            return res;
        }

        public static VectorUInt operator -(VectorUInt v, int scalar)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = (uint)(v.IntArray[i] - scalar);
            return res;
        }

        public static VectorUInt operator *(VectorUInt a, VectorUInt b)
        {
            VectorUInt larger = GetLarger(a, b, out uint min);
            VectorUInt res = new VectorUInt(larger.size);
            for (uint i = 0; i < larger.size; i++) res.IntArray[i] = larger.IntArray[i];
            for (uint i = 0; i < min; i++) res.IntArray[i] = a.IntArray[i] * b.IntArray[i];
            return res;
        }

        public static VectorUInt operator *(VectorUInt v, int scalar)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = (uint)(v.IntArray[i] * scalar);
            return res;
        }

        public static VectorUInt operator /(VectorUInt a, VectorUInt b)
        {
            VectorUInt larger = GetLarger(a, b, out uint min);
            VectorUInt res = new VectorUInt(larger.size);
            for (uint i = 0; i < larger.size; i++) res.IntArray[i] = larger.IntArray[i];
            for (uint i = 0; i < min; i++) res.IntArray[i] = b.IntArray[i] != 0 ? a.IntArray[i] / b.IntArray[i] : 0;
            return res;
        }

        public static VectorUInt operator /(VectorUInt v, short scalar)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = scalar != 0 ? (uint)(v.IntArray[i] / scalar) : 0;
            return res;
        }

        public static VectorUInt operator %(VectorUInt a, VectorUInt b)
        {
            VectorUInt larger = GetLarger(a, b, out uint min);
            VectorUInt res = new VectorUInt(larger.size);
            for (uint i = 0; i < larger.size; i++) res.IntArray[i] = larger.IntArray[i];
            for (uint i = 0; i < min; i++) res.IntArray[i] = b.IntArray[i] != 0 ? a.IntArray[i] % b.IntArray[i] : 0;
            return res;
        }

        public static VectorUInt operator %(VectorUInt v, short scalar)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = scalar != 0 ? (uint)(v.IntArray[i] % scalar) : 0;
            return res;
        }

        public static VectorUInt operator |(VectorUInt a, VectorUInt b)
        {
            VectorUInt larger = GetLarger(a, b, out uint min);
            VectorUInt res = new VectorUInt(larger.size);
            for (uint i = 0; i < larger.size; i++) res.IntArray[i] = larger.IntArray[i];
            for (uint i = 0; i < min; i++) res.IntArray[i] = a.IntArray[i] | b.IntArray[i];
            return res;
        }

        public static VectorUInt operator |(VectorUInt v, uint scalar)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = v.IntArray[i] | scalar;
            return res;
        }

        public static VectorUInt operator ^(VectorUInt a, VectorUInt b)
        {
            VectorUInt larger = GetLarger(a, b, out uint min);
            VectorUInt res = new VectorUInt(larger.size);
            for (uint i = 0; i < larger.size; i++) res.IntArray[i] = larger.IntArray[i];
            for (uint i = 0; i < min; i++) res.IntArray[i] = a.IntArray[i] ^ b.IntArray[i];
            return res;
        }

        public static VectorUInt operator ^(VectorUInt v, uint scalar)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = v.IntArray[i] ^ scalar;
            return res;
        }

        public static VectorUInt operator >>(VectorUInt v, int shift)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = v.IntArray[i] >> shift;
            return res;
        }

        public static VectorUInt operator <<(VectorUInt v, int shift)
        {
            VectorUInt res = new VectorUInt(v.size);
            for (uint i = 0; i < v.size; i++) res.IntArray[i] = v.IntArray[i] << shift;
            return res;
        }

        public static bool operator ==(VectorUInt a, VectorUInt b)
        {
            if (a.size != b.size) return false;
            for (int i = 0; i < a.size; i++) if (a.IntArray[i] != b.IntArray[i]) return false;
            return true;
        }

        public static bool operator !=(VectorUInt a, VectorUInt b)
        {
            return !(a == b);
        }

        public static bool operator >(VectorUInt a, VectorUInt b)
        {
            if (a.size != b.size) return false;
            for (int i = 0; i < a.size; i++) if (a.IntArray[i] <= b.IntArray[i]) return false;
            return true;
        }

        public static bool operator >=(VectorUInt a, VectorUInt b)
        {
            if (a.size != b.size) return false;
            for (int i = 0; i < a.size; i++) if (a.IntArray[i] < b.IntArray[i]) return false;
            return true;
        }

        public static bool operator <(VectorUInt a, VectorUInt b)
        {
            if (a.size != b.size) return false;
            for (int i = 0; i < a.size; i++) if (a.IntArray[i] >= b.IntArray[i]) return false;
            return true;
        }

        public static bool operator <=(VectorUInt a, VectorUInt b)
        {
            if (a.size != b.size) return false;
            for (int i = 0; i < a.size; i++) if (a.IntArray[i] > b.IntArray[i]) return false;
            return true;
        }
    }

    struct EmployeeStruct
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public int BirthYear { get; set; }
        public double Salary { get; set; }

        public EmployeeStruct(string fullName, string position, int birthYear, double salary)
        {
            FullName = fullName; Position = position; BirthYear = birthYear; Salary = salary;
        }

        public string LastName => FullName.Split(' ')[0];
    }

    record EmployeeRecord(string FullName, string Position, int BirthYear, double Salary);

    class MatrixUint
    {
        protected uint[,] IntArray;
        protected int n, m;
        protected int codeError;
        protected static int num_m = 0;

        public MatrixUint()
        {
            n = 1; m = 1;
            IntArray = new uint[n, m];
            codeError = 0;
            num_m++;
        }

        public MatrixUint(int n, int m)
        {
            this.n = n; this.m = m;
            IntArray = new uint[n, m];
            codeError = 0;
            num_m++;
        }

        public MatrixUint(int n, int m, uint initValue)
        {
            this.n = n; this.m = m;
            IntArray = new uint[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    IntArray[i, j] = initValue;
            codeError = 0;
            num_m++;
        }

        ~MatrixUint()
        {
            Console.WriteLine("Об'єкт MatrixUint знищено.");
        }

        public void Input()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Matrix[{i},{j}] = ");
                    IntArray[i, j] = uint.Parse(Console.ReadLine());
                }
        }

        public void Print()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++) Console.Write($"{IntArray[i, j],5} ");
                Console.WriteLine();
            }
        }

        public static int GetNumM() => num_m;

        public int Rows => n;
        public int Cols => m;
        public int CodeError { get => codeError; set => codeError = value; }

        public uint this[int r, int c]
        {
            get
            {
                if (r < 0 || r >= n || c < 0 || c >= m) { codeError = -1; return 0; }
                return IntArray[r, c];
            }
            set
            {
                if (r < 0 || r >= n || c < 0 || c >= m) codeError = -1;
                else IntArray[r, c] = value;
            }
        }

        public uint this[int k]
        {
            get
            {
                int r = k / m;
                int c = k % m;
                if (r < 0 || r >= n || c < 0 || c >= m) { codeError = -1; return 0; }
                return IntArray[r, c];
            }
            set
            {
                int r = k / m;
                int c = k % m;
                if (r < 0 || r >= n || c < 0 || c >= m) codeError = -1;
                else IntArray[r, c] = value;
            }
        }

        public static MatrixUint operator +(MatrixUint a, MatrixUint b)
        {
            if (a.n != b.n || a.m != b.m) return a;
            MatrixUint res = new MatrixUint(a.n, a.m);
            for (int i = 0; i < a.n; i++)
                for (int j = 0; j < a.m; j++)
                    res.IntArray[i, j] = a.IntArray[i, j] + b.IntArray[i, j];
            return res;
        }

        public static MatrixUint operator +(MatrixUint a, uint scalar)
        {
            MatrixUint res = new MatrixUint(a.n, a.m);
            for (int i = 0; i < a.n; i++)
                for (int j = 0; j < a.m; j++)
                    res.IntArray[i, j] = a.IntArray[i, j] + scalar;
            return res;
        }

        public static bool operator true(MatrixUint m) => m.n > 0 && m.m > 0;
        public static bool operator false(MatrixUint m) => m.n == 0 || m.m == 0;
    }
}