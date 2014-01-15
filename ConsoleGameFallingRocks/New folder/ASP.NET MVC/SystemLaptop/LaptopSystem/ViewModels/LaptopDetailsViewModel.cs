using LaptopSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LaptopSystem.ViewModels
{
    public class LaptopDetailsViewModel
    {
        public int LaptopId { get; set; }

        public string Model { get; set; }

        public double Monitor { get; set; }

        public string ImageUrl { get; set; }

        public int? HardDisk { get; set; }

        public int? RAM { get; set; }

        public decimal Price { get; set; }

        public double? Weight { get; set; }

        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public string  Manufacturer { get; set; }

        public int Votes { get; set; }

        public bool UserCanVote { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Laptop, LaptopDetailsViewModel>> FromLaptop
        {
            get
            {
                return laptop => new LaptopDetailsViewModel
                {
                    LaptopId = laptop.LaptopId,
                    Manufacturer = laptop.Manufacturer.Name,
                    Model = laptop.Model,
                    ImageUrl = laptop.ImageUrl,
                    Price = laptop.Price,
                    AdditionalParts = laptop.AdditionalParts,
                    Description = laptop.Description,
                    HardDisk = laptop.HardDisk,
                    Monitor = laptop.Monitor,
                    RAM = laptop.RAM,
                    Weight = laptop.Weight,
                    Votes = laptop.Votes.Count(),
                    UserCanVote = true,
                    Comments = laptop.Comments.Select(x => new CommentViewModel
                    {
                        CommentedBy = x.User.UserName,
                        Content = x.Content,
                        CommentId = x.CommentId
                    })
                };
            }
        }
    }
}