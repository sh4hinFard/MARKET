using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Be;
using DAL;
using MARKET.Service;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MARKET.Models
{

    //public class UserService
    //{
    //    private db _context;

    //    public UserService(db context)
    //    {
    //        _context = context;
    //    }


    //    public bool CheckUserName(string userName)
    //    {
    //        return _context.users.Any(t => t.username == userName);
    //    }

    //    public bool CheckEmail(string email)
    //    {
    //        return _context.users.Any(t => t.email == FixText.FixEmail(email));
    //    }

    //    public void AddUser(Be.User user)
    //    {
    //        _context.users.Add(user);
    //        _context.SaveChanges();
    //    }

    //    public User LoginUser(LoginViewModel login)
    //    {
    //        var email = FixText.FixEmail(login.Email);
    //        var password = PasswordHash.EncodePasswordMd5(login.Password);
    //        var user = _context.users.SingleOrDefault(t => t.email == email && t.password == password);
    //        return user;
    //    }

    //    public bool CheckActiveAccount(string activeCode)
    //    {
    //        var user = _context.users.SingleOrDefault(t => t.ActiveCode == activeCode);
    //        if (user == null || user.IsActive)
    //            return false;

    //        user.IsActive = true;
    //        user.ActiveCode = NameGenerator.GeneratorUniqCode();
    //        _context.SaveChanges();
    //        return true;
    //    }

    //    public User GetUserByEmail(string email)
    //    {
    //        return _context.users.SingleOrDefault(t => t.email == email);
    //    }

    //    public User GetUserByActiveCode(string activeCode)
    //    {
    //        return _context.users.SingleOrDefault(t => t.ActiveCode == activeCode);
    //    }

    //    public void UpdteUser(User user)
    //    {
    //        _context.Update(user);
    //        _context.SaveChanges();
    //    }

    //    public UserInfoViewModel GetUserModelByUserName(string userName)
    //    {
    //        var user = _context.users.SingleOrDefault(t => t.username == userName);
    //        return new UserInfoViewModel()
    //        {
    //            UserName = user.username,
    //            AmountWallet = BalanceUserWallet(userName).ToString(),
    //            Email = FixText.FixEmail(user.email),
    //            RegisterDate = user.RegisterDate
    //        };
    //        //UserInfoViewModel model = new UserInfoViewModel()
    //        //{
    //        //    UserName = user.UserName,
    //        //    AmountWallet = "200000",
    //        //    Email = FixText.FixEmail(user.Email),
    //        //    RegisterDate = user.RegisterDate
    //        //};
    //        //return model;
    //    }

    //    public SideBarViewModel GetSideBarByUserName(string userName)
    //    {
    //        var user = _context.users.SingleOrDefault(t => t.username == userName);
    //        return new SideBarViewModel()
    //        {
    //            FullName = user.username,
    //            ImageName = user.UserImage,
    //            RegisterDate = user.RegisterDate
    //        };
    //    }

    //    public EditProfileViewModel GetDataEditProfile(string userName)
    //    {
    //        return _context.users.Where(t => t.username == userName).Select(item => new EditProfileViewModel()
    //        {
    //            UserName = item.username,
    //            Email = item.email,
    //            ImageName = item.UserImage
    //        }).Single();
    //    }

    //    public void EditProfile(string userName, EditProfileViewModel editProfile)
    //    {
    //        if (editProfile.ImageFile != null)
    //        {
    //            string imagePath = "";
    //            if (editProfile.ImageName != "nophoto.png")
    //            {
    //                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/User", editProfile.ImageName);
    //                if (File.Exists(imagePath))
    //                {
    //                    File.Delete(imagePath);
    //                }
    //            }

    //            editProfile.ImageName = NameGenerator.GeneratorUniqCode() + Path.GetExtension(editProfile.ImageFile.FileName);
    //            imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/User", editProfile.ImageName);
    //            using (var stream = new FileStream(imagePath, FileMode.Create))
    //            {
    //                editProfile.ImageFile.CopyTo(stream);
    //            }

    //        }
    //        var user = GetUser(userName);
    //        user.username = editProfile.UserName;
    //        user.email = FixText.FixEmail(editProfile.Email);
    //        user.UserImage = editProfile.ImageName;
    //        UpdteUser(user);
    //    }

    //    public User GetUser(string userName)
    //    {
    //        return _context.users.SingleOrDefault(t => t.username == userName);
    //    }

    //    public bool CheckOldPassword(string userName, string oldPassword)
    //    {
    //        string hashOldPass = PasswordHash.EncodePasswordMd5(oldPassword);
    //        return _context.users.Any(t => t.username == userName && t.password == hashOldPass);
    //    }

    //    public void ChangePassword(string userName, string password)
    //    {
    //        string hashPass = PasswordHash.EncodePasswordMd5(password);
    //        var user = GetUser(userName);
    //        user.password = hashPass;
    //        UpdteUser(user);
    //    }

    //    public int BalanceUserWallet(string userName)
    //    {
    //        var userId = GetuserIdByUserName(userName);
    //        var deposit = _context.wallets.Where(t => t.UserId == userId && t.WalleTypetId == 1 && t.IsPay).Select(t => t.Amount).ToList();
    //        var harvest = _context.wallets.Where(t => t.UserId == userId && t.WalleTypetId == 2 && t.IsPay).Select(t => t.Amount).ToList();
    //        return deposit.Sum() - harvest.Sum();
    //    }

    //    public int GetuserIdByUserName(string userName)
    //    {
    //        return _context.users.SingleOrDefault(t => t.username == userName).Id;
    //    }

    //    public List<WalletViewModel> GetWalletsByUserName(string userName)
    //    {
    //        var userId = GetuserIdByUserName(userName);
    //        return _context.wallets.Where(t => t.UserId == userId).Select(item => new WalletViewModel()
    //        {
    //            Amount = item.Amount,
    //            Description = item.Description,
    //            IsPay = item.IsPay,
    //            RegisterDate = item.RegisterDate,
    //            TypeId = item.WalleTypetId
    //        }).ToList();

    //    }

    //    public int ChargeWallet(string userName, int amount, string description, bool isPay = false)
    //    {
    //        var userId = GetuserIdByUserName(userName);
    //        Wallet wallet = new Wallet()
    //        {
    //            Amount = amount,
    //            Description = description,
    //            IsPay = isPay,
    //            RegisterDate = System.DateTime.Now,
    //            UserId = userId,
    //            WalleTypetId = 1
    //        };
    //        return AddWaalet(wallet);
    //    }

    //    public int AddWaalet(Wallet wallet)
    //    {
    //        _context.wallets.Add(wallet);
    //        _context.SaveChanges();
    //        return wallet.Id;
    //    }

    //    public Wallet GetWalletByWalletId(int walletId)
    //    {
    //        return _context.wallets.Find(walletId);
    //    }

    //    public void UpdateWallet(Wallet wallet)
    //    {
    //        _context.wallets.Update(wallet);
    //        _context.SaveChanges();
    //    }

    //    public UserViewModel GetUsers(int pageId = 1, string userName = "", string email = "")
    //    {
    //        IQueryable<User> query = _context.users;

    //        if (!string.IsNullOrEmpty(userName))
    //        {
    //            query = query.Where(t => t.username.Contains(userName));
    //        }

    //        if (!string.IsNullOrEmpty(email))
    //        {
    //            query = query.Where(t => t.email.Contains(email));
    //        }

    //        int take = 20;
    //        int skip = (pageId - 1) * 20;
    //        UserViewModel model = new UserViewModel();
    //        model.CurrentPage = pageId;
    //        model.PageCount = query.Count() / take;
    //        model.Users = query.OrderBy(t => t.RegisterDate).Skip(skip).Take(take).ToList();
    //        return model;
    //    }

    //    public int AddUserInAdmin(CreateUserViewModel create)
    //    {
    //        string imageName = "nophoto.png";
    //        if (create.ImageFile != null)
    //        {
    //            string imagePath = "";
    //            imageName = NameGenerator.GeneratorUniqCode() + Path.GetExtension(create.ImageFile.FileName);
    //            imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPic", imageName);
    //            using (var stream = new FileStream(imagePath, FileMode.Create))
    //            {
    //                create.ImageFile.CopyTo(stream);
    //            }
    //        }
    //        User user = new User()
    //        {
    //            UserImage = imageName,
    //            email = FixText.FixEmail(create.Email),
    //            username = create.UserName,
    //            RegisterDate = DateTime.Now,
    //            password = PasswordHash.EncodePasswordMd5(create.Password),
    //            IsActive = true,
    //            ActiveCode = NameGenerator.GeneratorUniqCode()
    //        };
    //        _context.users.Add(user);
    //        _context.SaveChanges();
    //        return user.Id;
    //    }

    //    public User GetUserByUserId(int userId)
    //    {
    //        return _context.users.Find(userId);
    //    }

    //    public EditUserViewModel GetEditUserViewModelByUserId(int userId)
    //    {
    //        return _context.users.Where(t => t.Id == userId).Select(item => new EditUserViewModel()
    //        {
    //            UserImage = item.UserImage,
    //            UserId = item.Id,
    //            Email = item.email,
    //            UserName = item.username,
    //            SelectedRoles = _context.UserRoles.Where(t => t.UserId == userId).Select(t => t.RoleId).ToList()
    //        }).Single();
    //    }

    //    public void UpdateUserInAdmin(EditUserViewModel edit)
    //    {
    //        var user = GetUserByUserId(edit.UserId);
    //        if (edit.ImageFile != null)
    //        {
    //            string imagePath = "";
    //            if (edit.UserImage != "nophoto.png")
    //            {
    //                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPic", edit.UserImage);
    //                if (File.Exists(imagePath))
    //                {
    //                    File.Delete(imagePath);
    //                }

    //            }
    //            user.UserImage = NameGenerator.GeneratorUniqCode() + Path.GetExtension(edit.ImageFile.FileName);
    //            imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPic", user.UserImage);
    //            using (var stream = new FileStream(imagePath, FileMode.Create))
    //            {
    //                edit.ImageFile.CopyTo(stream);
    //            }
    //        }

    //        if (!string.IsNullOrEmpty(edit.Password))
    //        {
    //            user.password = PasswordHash.EncodePasswordMd5(edit.Password);
    //        }

    //        user.email = FixText.FixEmail(edit.Email);
    //        user.Id = edit.UserId;
    //        user.username = edit.UserName;
    //        _context.users.Update(user);
    //        _context.SaveChanges();
    //    }

    //    public UserViewModel GetDeleteUsers(int pageId = 1, string userName = "", string email = "")
    //    {
    //        IQueryable<User> query = _context.users.IgnoreQueryFilters().Where(u => u.IsDelete);

    //        if (!string.IsNullOrEmpty(userName))
    //        {
    //            query = query.Where(t => t.username.Contains(userName));
    //        }

    //        if (!string.IsNullOrEmpty(email))
    //        {
    //            query = query.Where(t => t.email.Contains(email));
    //        }

    //        int take = 20;
    //        int skip = (pageId - 1) * 20;
    //        UserViewModel model = new UserViewModel();
    //        model.CurrentPage = pageId;
    //        model.PageCount = query.Count() / take;
    //        model.Users = query.OrderBy(t => t.RegisterDate).Skip(skip).Take(take).ToList();
    //        return model;
    //    }

    //    public void DeleteUser(int userId)
    //    {
    //        var user = GetUserByUserId(userId);
    //        user.IsDelete = true;
    //        UpdteUser(user);
    //    }

    //    public InfoUserViewModel GetInfoUser(int userId)
    //    {
    //        return _context.users.Where(t => t.Id == userId).Select(item => new InfoUserViewModel()
    //        {
    //            UserId = item.Id,
    //            Email = item.email,
    //            UserName = item.username
    //        }).Single();

    //    }

    //    public List<SelectListItem> GetTeacherName()
    //    {
    //        return _context.UserRoles.Where(u => u.RoleId == 2).Include(u => u.User).Select(u => new SelectListItem()
    //        {
    //            Text = u.User.UserName,
    //            Value = u.UserId.ToString()
    //        })
    //            .ToList();
    //    }
    //}

}
