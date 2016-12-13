using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Proeftentamen
{
    public class TentamenPrg2Proef20162017
    {
        //Vraag 1 (1.5pt)
        //Gegeven is een array met getallen (xs), bepaal welk getal het dichtst bij nul ligt.
        //
        //Voor het laatste 0.5 punt: een positief getal heeft voorrang op een negatief getal 
        //(zie het laatste voorbeeld/testcase hieronder). 
        //Tip: gebruik Math.Abs(..).
        //Deze methode geeft altijd een positief getal terug.Math.Abs(-3) --> 3, Math.Abs(3) --> 3. 
        [Test]
        public void Test_Vraag1()
        {
            Assert.AreEqual(0, Vraag1(new int[] { }));
            Assert.AreEqual(3, Vraag1(new int[] { -5, 4, 3, 8 }));
            Assert.AreEqual(-3, Vraag1(new int[] { 5, 4, -3, 8 }));
            Assert.AreEqual(3, Vraag1(new int[] { 5, 3, 4, -3, 8 }));
        }

        public int Vraag1(int[] xs)
        {
            if (xs.Length == 0)
            {
                return 0;
            }
            int smallest = xs[0];
            foreach (int i in xs)
            {
                if (Math.Abs(i) < Math.Abs(smallest))
                {
                    smallest = i;
                }
                if (Math.Abs(i) <= Math.Abs(smallest) && i > 0)
                {
                    smallest = i;
                }
            }
            return smallest;
        }

        //Vraag 2 (1.5pt)        
        //Gegeven is een array met decimalen van een getal (integers). Maak van deze decimale het bijbehorende getal.
        //Dus b.v. {1, 0, 2, 4} wordt 1024.
        [Test]
        public void Test_Vraag2()
        {
            Assert.AreEqual(0, Vraag2(new int[] { }));
            Assert.AreEqual(2, Vraag2(new int[] { 2 }));
            Assert.AreEqual(25, Vraag2(new int[] { 2, 5 }));
            Assert.AreEqual(123, Vraag2(new int[] { 1, 2, 3 }));
            Assert.AreEqual(1024, Vraag2(new int[] { 1, 0, 2, 4 }));
        }

        public int Vraag2(int[] xs)
        {
            int result = 0;
            for (int i = 0; i < xs.Length; i++)
            {
                result *= 10;
                result += xs[i];
            }
            return result;
        }

        //Vraag 3 (2pt)
        //Plaats het getal op ide-index in de array vooraan. Je mag geen nieuwe array aanmaken.
        //i=3  {0, 1, 2, 3, 4, 5} --> {3, 0, 1, 2, 4, 5}

        //In het volgende voorbeeld wordt de waarde 6 die zich op de 2de index in de array 
        //bevindt vooraan in de array gezet.     
        //i=2   {0, 5, 6, 7, 8} --> {6, 0, 5, 7, 8}

        //Je mag ervan uit gaan dat de index altijd een geldige waarde bevat.

        [Test]
        public void Test_Vraag3()
        {
            {
                int[] inputOutput = { 2, 5, 6, 7, 8, -2 };
                Vraag3(inputOutput, 2);
                Assert.AreEqual(new int[] { 6, 2, 5, 7, 8, -2 }, inputOutput);
            }
            {
                int[] inputOutput = { 0, 1, 2, 3, 4, 5 };
                Vraag3(inputOutput, 3);
                Assert.AreEqual(new int[] { 3, 0, 1, 2, 4, 5 }, inputOutput);
            }

            {
                int[] inputOutput = { 0, 5, 6, 7, 8 };
                Vraag3(inputOutput, 2);
                Assert.AreEqual(new int[] { 6, 0, 5, 7, 8 }, inputOutput);
            }
        }

        public void Vraag3(int[] xs, int index)
        {
            int temp = xs[index];
            for (int i = index; i > 0; i--)
            {
                xs[i] = xs[i - 1];
            }
            xs[0] = temp;
        }

        //Vraag 4 (2 pt)
        //Maak een methode die de volgende reeks berekent: 
        //2, 5, 26, 577, …
        //De n-de term kan berekend worden door de vorige term te vermenigvuldigen met zichzelf en er 1 bij te tellen.
        //De eerste term is 2.
        //5 = 2*2 + 1
        //26 = 5*5 + 1
        //577 = 26*26 + 1
        //De methode retourneert een lijst van de eerste k termen.
        //k = 1 --> {2}
        //k = 2 --> {2, 5}
        //k = 3 --> {2, 5, 26}

        [Test]
        public void Test_Vraag4()
        {
            Assert.AreEqual(new List<int>() { 2 }, Vraag4(1));
            Assert.AreEqual(new List<int>() { 2, 5 }, Vraag4(2));
            Assert.AreEqual(new List<int>() { 2, 5, 26 }, Vraag4(3));
        }

        public List<int> Vraag4(int k)
        {
            int term = 2;
           List<int> results = new List<int>();
            for (int i = 0; i < k; i++)
            {
                results.Add(term);
                term = term * term + 1;
            }
            return results;
        }


        //Vraag 5 (2pt)
        //Gegeven is dezelfde studenten database net zoals in het practicum (zie appendix of StudentenDatabase.cs). 
        //Maak een methode die uitzoekt welke student het meeste examens heeft gedaan. 
        //Retourneer de naam van deze student.
        //Opmerking: je mag ervan uitgaan dat er één zo’n student is.  

        //Voor de laatste 0.5 punt doe je dit efficiënt (De StudentNr’s lopen van 1..N, waarbij N het aantal vakken is).  
        [Test]
        public void Test_Vraag5()
        {
            Assert.AreEqual("Jan", MeesteExamensVoorStudent(StudentDatabase.Students, StudentDatabase.Courses, StudentDatabase.Exams));
        }

        public string MeesteExamensVoorStudent(List<Student> students,
                                                List<Course> courses,
                                                List<Exam> exams)
        {
            int maxCount = 0;
            string nameStudent = "";
            foreach (Student s in students)
            {
                int count = 0;
                foreach (Exam e in exams)
                {
                    if (s == e.Student)
                    {
                        count++;
                    }
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    nameStudent = s.Name;
                }
            }
            return nameStudent;
        }
    }
}
