using System;
using Windows.ApplicationModel.Contacts;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using ExamUW.Entities;
using ExamUW.Utils;

namespace ExamUW
{
    class ContactModel
    {
        public bool Insert(Entities.Contact contact)
        {
            try
            {
                using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("INSERT INTO Contact (Name, Phone) VALUES (?,?)"))
                {
                    stt.Bind(1, contact.Name);
                    stt.Bind(2, contact.Phone);
                    stt.Step();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        public ObservableCollection<ExamUW.Entities.Contact> SearchContacts()
        {
            try
            {
                var list = new ObservableCollection<ExamUW.Entities.Contact>();
                using (var stt = SQLiteUtil.GetIntances().Connection.Prepare("SELECT * FROM Contact"))
                {

                    while (stt.Step() == SQLiteResult.ROW)
                    {
                        list.Add(new ExamUW.Entities.Contact
                        {
                            Name = (string)stt[1],
                            Phone = (int)stt[2],
                        });
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

    }
}