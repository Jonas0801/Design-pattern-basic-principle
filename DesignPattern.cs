using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonas
{
    public class DesignPattern : MonoBehaviour
    {
        void Start()
        {
            //設計模式, 基本7大原則

            #region SRP 單一則責任原則 Single Responsibility Principle
            SRP.IPhone12s jonasIphone1 = new SRP.IPhone12s();
            jonasIphone1.Phone.Dial("0987-878-878");
            jonasIphone1.Massage.Send("0987-878-878", "0857");
            #endregion

            #region DIP 依賴反轉原則 Dependency Inversion Principle
            DIP.IPhone12s jonasIphone2 = new DIP.IPhone12s();
            jonasIphone2.Read(new DIP.SMS());
            jonasIphone2.Read(new DIP.Line());
            jonasIphone2.Read(new DIP.Email());
            #endregion

            #region OCP 開放封閉原則 Open/Close Principle
            OCP.Edit edit = new OCP.Edit();
            edit.Draw(new OCP.Rectangle());
            #endregion

            #region LSP 里氏替換原則 Liskov's Substitution Principle
            LSP.IPerson p1 = new LSP.Engineer();
            LSP.IPerson p2 = new LSP.Student();
            p1.Say();
            p2.Say();

            #endregion

            #region ISP 介面隔離原則 Interface Segregation Principle
            ISP.UnityEngineer jonas = new ISP.UnityEngineer();
            jonas.WriteCode();
            jonas.Walk();
            jonas.Say();

            ISP.MathTeacher renee = new ISP.MathTeacher();
            renee.Say();
            renee.Walk();
            renee.Teach();
            #endregion

            #region LKP 最少知識原則 Least Knowledge Principle
            List<LKP.Customer> customers = new List<LKP.Customer>() 
            { 
                new LKP.Customer(new LKP.Wallet(1000)),
                new LKP.Customer(new LKP.Wallet(500)),
                new LKP.Customer(new LKP.Wallet(10000)),
                new LKP.Customer(new LKP.Wallet(900)),
                new LKP.Customer(new LKP.Wallet(10))
            };

            LKP.Waiter waiter = new LKP.Waiter();
            waiter.SetCustomers(customers);
            waiter.CollectMoney();
            #endregion

            #region CARP 合成聚合復用原則 Composite/Aggregate Reuse Principle
            CARP.CRV crv = new CARP.CRV();
            crv.color = new CARP.White();
            crv.color.Kind();
            crv.Run();
            #endregion

        }
    }
    namespace SRP
    {
        //SRP 單一則責任原則 Single Responsibility Principle
        //一個類只負責一件事 且只有一個原因修改這個類
        interface IPhone
        {
            void Dial(string phoneNumber);
            void HangUp();
        }
        interface IMassage
        {
            void Send(string phoneNumber, string massageStr);
            void Receive();
        }

        public class Phone : IPhone
        {
            public void Dial(string phoneNumber)
            {
                Debug.Log($"打給{phoneNumber}");
            }

            public void HangUp()
            {
            }
        }
        public class Massage : IMassage
        {
            public void Receive()
            {
            }

            public void Send(string phoneNumber, string massageStr)
            {
                Debug.Log($"傳送訊息{massageStr}給{phoneNumber}");
            }
        }

        public class IPhone12s
        {
            private Phone phone;
            public Phone Phone
            {
                get { return phone == null ? phone = new Phone() : phone; }
                private set { phone = value; }
            }

            private Massage massage;
            public Massage Massage
            {
                get { return massage == null ? massage = new Massage() : massage; }
                set { massage = value; }
            }
        }
    }
    namespace DIP
    {
        // DIP 依賴反轉原則 Dependency Inversion Principle
        //高層模組不應該依賴低層模組, 他們都應該依賴抽象
        //抽象不應該依賴細節(實作類), 細節應該依賴抽象(interface 或 abstract)
        public interface IReceiver
        {
            string Message();
        }

        public class Line : IReceiver
        {
            public string Message()
            {
                return "line msg";
            }
        }

        public class Email : IReceiver
        {
            public string Message()
            {
                return "email msg";
            }
        }

        public class SMS : IReceiver
        {
            public string Message()
            {
                return "sms msg";
            }
        }

        public class IPhone12s
        {
            public void Read(IReceiver receiver) { Debug.Log(receiver.Message()); }
        }
    }
    namespace OCP
    {
        //OCP 開放封閉原則 Open/Close Principle
        //開放擴增, 封閉修改
        public abstract class Shape
        {
            public abstract void Draw();
        }

        public class Triangle : Shape
        {
            public override void Draw()
            {
                Debug.Log("draw triangle");
            }
        }

        public class Rectangle : Shape
        {
            public override void Draw()
            {
                Debug.Log("draw rectangle");
            }

        }

        public class Edit
        {
            public void Draw(Shape shape)
            {
                shape.Draw();
            }
        }
    }
    namespace LSP
    {
        //LSP 里氏替換原則 Liskov's Substitution Principle
        //子類別必須能夠替換父類別, 並且行為正常

        public interface IPerson
        {
            void Say();
        }

        public class Student : IPerson
        {
            public void Say()
            {
                Debug.Log(GetType().Name);
            }
        }

        public class Engineer : IPerson
        {
            public void Say()
            {
                Debug.Log(GetType().Name);
            }
        }
    }
    namespace ISP
    {
        //ISP 介面隔離原則 Interface Segregation Principle
        //不應該強迫用戶去依賴他們未使用的方法
        public interface IPerson
        {
            void Say();
            void Walk();
        }

        public interface IEngineer : IPerson
        {
            void WriteCode();
        }

        public interface ITeacher : IPerson
        {
            void Teach();
        }

        public class UnityEngineer : IEngineer
        {
            public void Say()
            {
                Debug.Log($"我是{GetType().Name}, 我會講話");
            }

            public void Walk()
            {
                Debug.Log($"我是{GetType().Name}, 我會走路");
            }

            public void WriteCode()
            {
                Debug.Log($"我是{GetType().Name}, 我會打code");
            }
        }

        public class MathTeacher : ITeacher
        {
            public void Say()
            {
                Debug.Log($"我是{GetType().Name}, 我會講話");
            }

            public void Walk()
            {
                Debug.Log($"我是{GetType().Name}, 我會走路");
            }

            public void Teach()
            {
                Debug.Log($"我是{GetType().Name}, 我會教書");
            }
        }

    }
    namespace LKP
    {
        //LKP 最少知識原則 Least Knowledge Principle
        //已經成形的操作流程就封裝起來, 一個物件應該對其他物件有最少的瞭解

        public class Wallet
        {
            public int Money { get; set; }

            public Wallet(int money)
            {
                this.Money = money;
            }

            public override string ToString()
            {
                return GetType().Name + "剩餘 $" + Money;
            }
        }

        public class Customer
        {
            private Wallet myWallet;
            public Customer(Wallet wallet)
            {
                this.myWallet = wallet;
            }

            public int GetPayment(int payment)
            {
                if (myWallet == null)
                {
                    Debug.Log($"{GetType().Name}錢包不見了~");
                    return 0;
                }

                if (myWallet.Money >= payment)
                {
                    myWallet.Money -= payment;
                    Debug.Log($"{GetType().Name}, 已支付{payment}");
                    return payment;
                }
                else
                {
                    Debug.Log($"{GetType().Name}, {myWallet}不夠付~");
                    return 0;
                }
            }
        }

        public class Waiter
        {
            public List<Customer> customers;
            public void SetCustomers(List<Customer> customers)
            {
                this.customers = customers;
            }

            public void CollectMoney()
            {
                customers.ForEach((customer) => { customer.GetPayment(1000); });
            }
        }
    }
    namespace CARP
    {
        //CARP 合成聚合復用原則 Composite/Aggregate Reuse Principle
        //盡量使用組合(contains-a)/聚合(has-a)方式來代替繼承(is-a)來達到重複使用的目的
        //組合：部分對象以及整體對象的生命週期是一致的。
        //聚合：部分對象的生命週期與整體對象沒有關聯，甚至可能更長。
        //組合 必須擁有
        //聚合 給予
        #region example
        class Learn { }
        class Heart { }

        class person
        {
            Heart heart = new Heart(); //組合
            Learn learn = null;//聚合

            public person(Learn learn)
            {
                this.learn = learn;
            }
        }
        #endregion

        public interface Color
        {
            void Kind();
        }

        public abstract class Car
        {
            public Color color { get; set; }
            public abstract void Run();
        }

        public class CRV : Car
        {
            public override void Run()
            {
                Debug.Log(GetType().Name + "跑起來");
            }
        }

        public class White : Color
        {
            public void Kind()
            {
                Debug.Log($"顏色是 : {GetType().Name}");
            }
        }
    }
}

