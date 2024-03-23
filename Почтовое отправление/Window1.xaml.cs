using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Почтовое_отправление;

namespace Почтовое_отправление
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string numbers = "1234567890";
        string BigChars = "QWERTYUIOPASDFGHJKLZXCVBNMЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ";
        string smallchars = "qwertyuiopasdfghjklzxcvbnmйцукенгшщзхъфывапролджэячсмитьбю";
        string[] sponsors = { "FTS", "Roscomnadzor", "EA", "Mezentceva", "ФНС", "Роскомнадзор", "Мезенцева" };
        string[] fhrases = {
                             "i'm gay", "i'm whore", "i'm traitor of rodina", "i'm love mezentceva", 
                             "I'm gay", "I'm whore", "I'm traitor of rodina", "I'm love mezentceva", 
                             "я гей","я шлюха","я предатель родины","я люблю мезенцеву", 
                             "Я гей","Я шлюха","Я предатель родины","Я люблю мезенцеву", 
                            };
        string[] fhrase = { "i'm agree all, master", "I'm agree all, master", "я согласен на всё, хозяин", 
                            "Я согласен на всё, хозяин", "я согласна на всё, хозяин", "Я согласна на всё, хозяин" };
        public Window1()
        {
            InitializeComponent();
        }
        private bool CheckNumbers(string password)
        {
            foreach (char i in numbers)
            {
                if (pas.Text.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckBigChars(string password)
        {
            foreach (char i in BigChars)
            {
                if (pas.Text.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }
        private bool Checksmallchars(string password)
        {
            foreach (char i in smallchars)
            {
                if (pas.Text.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckSponsors(string password)
        {
            foreach (string i in sponsors)
            {
                if (pas.Text.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckFhrases(string password)
        {
            foreach (string i in fhrases)
            {
                if (pas.Text.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckFhrase(string password)
        {
            foreach (string i in fhrase)
            {
                if (pas.Text.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckNumbers2(string password)
        {
            int summ = 0;
            foreach (char i in password)
            {
                try
                {
                    summ += Int32.Parse("" + i);
                }
                catch
                {

                }
            }
            if (summ % 40 == 0) 
            { 
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckDateTime(string password)
        {
            if (password.Contains(DateTime.Now.Minute.ToString()))
            {
                return true;
            }
            else
            {
                return false ;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestTech con = new TestTech()
            {
                LOGIN = log.Text,
                PASSWORD = pas.Text
            };
            

            if (CheckDateTime(pas.Text) & CheckBigChars(pas.Text) & CheckFhrase(pas.Text) & CheckNumbers(pas.Text) & Checksmallchars(pas.Text) & CheckSponsors(pas.Text) & CheckFhrases(pas.Text) & CheckNumbers2(pas.Text))
            {
                try
                {
                    Class1.context.TestTech.Add(con);
                    Class1.context.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались");
                    MainWindow ax = new MainWindow();
                    ax.Show();
                    this.Close();
                }

                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);
                    
                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }
            else if (!CheckNumbers(pas.Text))
            {
                MessageBox.Show("Пароль должен содержать цифры");
                
            }
            else if (!CheckBigChars(pas.Text))
            {
                MessageBox.Show("Пароль должен содержать Большие Буквы");
            }
            else if (!CheckDateTime(pas.Text))
            {
                MessageBox.Show("Пароль должен содержать текущее количество vbyen по примеру по приеру -\n" + DateTime.UtcNow.Minute.ToString());
            }
            else if (!Checksmallchars(pas.Text))
            {
                MessageBox.Show("Пароль должен содержать маленькие буквы");
            }
            else if (!CheckSponsors(pas.Text))
            {
                MessageBox.Show("Пароль должен содержать спонсоров, а именно компании сотоящей в триаде зла, а именно:\n- FTS\n- Roscomnadzor\n- EA\n- Mezentceva");
            }
            else if (!CheckFhrases(pas.Text))
            {
                MessageBox.Show("Пароль должен содержать фразы\n- \"i'm gay\"\n- \"i'm whore\"\n- \"i'm traitor of rodina\"\n- \"i'm love mezentceva\"");
            }
            else if (!CheckFhrase(pas.Text))
            {
                MessageBox.Show("Пароль должен содержать согласие вообще на всё по образцу: \n\"i'm agree all, master\"");
            }
            else if (!CheckNumbers2(pas.Text))
            {
                MessageBox.Show("Сумма цифр в пароле должна делится на 40");
            }
            

        }
        //Aaa55555555EA i'm gay i'm agree all, master

    }

}
