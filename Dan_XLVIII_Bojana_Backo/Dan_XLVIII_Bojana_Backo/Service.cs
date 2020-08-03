using System;
using System.Collections.Generic;
using System.Linq;

namespace Dan_XLVIII_Bojana_Backo
{
    class Service
    {
        public static tblUser userGuest = new tblUser();
        public static int userId = 1;
        // Method that add user to database by his jmbg
        public tblUser AddUser(string user)
        {
            try
            {
                using (PizzeriaEntities context = new PizzeriaEntities())
                {
                    tblUser newUser = new tblUser();
                    newUser.jmbg = user;
                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    userId = newUser.UserID;
                    return newUser;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        // Methot to check if User has already make an order in the past
        public bool IsUser(string jmbg)
        {
            try
            {
                using (PizzeriaEntities context = new PizzeriaEntities())
                {
                    tblUser emloyee = (from e in context.tblUsers where e.jmbg == jmbg select e).First();

                    if (emloyee == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public tblUser FindUser(string jmbg)
        {
            try
            {
                using (PizzeriaEntities context = new PizzeriaEntities())
                {
                    tblUser user = (from e in context.tblUsers where e.jmbg == jmbg select e).First();
                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        // Method that add order to database
        public void AddOrder(tblOrder order)
        {
            try
            {
                using (PizzeriaEntities context = new PizzeriaEntities())
                {
                    tblOrder newOrder = new tblOrder();
                    newOrder.Name = order.Name;
                    newOrder.OrderDate = DateTime.Now;
                    newOrder.Price = order.Price;
                    newOrder.OrderStatus = "on hold";
                    newOrder.UserID = userId;
                    context.tblOrders.Add(newOrder);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
        // Method that reads all orders from database
        public List<tblOrder> GetAllOrders()
        {
            try
            {
                using (PizzeriaEntities context = new PizzeriaEntities())
                {
                    List<tblOrder> list = new List<tblOrder>();
                    list = (from x in context.tblOrders select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        // Mhetod that reads users order
        public List<tblOrder> GetUserOrder()
        {
            try
            {
                using (PizzeriaEntities context = new PizzeriaEntities())
                {
                    List<tblOrder> order = new List<tblOrder>();
                    order = (from e in context.tblOrders where e.UserID == userId select e).ToList();
                    return order;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        // Method that archives order, delete from database
        public void ArchiveOrder(int orderID)
        {
            try
            {
                using (PizzeriaEntities context = new PizzeriaEntities())
                {

                    tblOrder orderToDelete = (from e in context.tblOrders where e.OrderID == orderID select e).First();
                    context.tblOrders.Remove(orderToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
        // Method that update order status
        public tblOrder EditOrderStatus(tblOrder order)
        {
            try
            {
                using (PizzeriaEntities context = new PizzeriaEntities())
                {
                    tblOrder orderToEdit = (from e in context.tblOrders where e.OrderID == order.OrderID select e).First();

                    tblOrder oldOrderStatus = new tblOrder();
                    oldOrderStatus.Name = order.Name;
                    oldOrderStatus.Price = order.Price;
                    oldOrderStatus.OrderStatus = order.OrderStatus;
                    oldOrderStatus.OrderDate = order.OrderDate;
                    oldOrderStatus.UserID = order.UserID;

                    orderToEdit.Name = order.Name;
                    orderToEdit.Price = order.Price;
                    orderToEdit.OrderStatus = order.OrderStatus;
                    orderToEdit.OrderDate = order.OrderDate;
                    orderToEdit.UserID = order.UserID;

                    context.SaveChanges();

                    return order;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
