using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.Models;

namespace ProjectManagement.ViewModels.Management
{
    public class VmBidding
    {
        public VmBidding()
        {
            CreateBidModels = new List<Bid_CreateBidModel>();
            CreateBidModel = new Bid_CreateBidModel();
            Bid_SparePartsDetailsModel1 = new Bid_SparePartsDetailsModel();
            Bid_SparePartsDetailsModels1 = new List<Bid_SparePartsDetailsModel>();
            Bid_SparePartsDetailsModel = new Bid_SparePartsDetailsModel();
            Bid_SparePartsDetailsModels = new List<Bid_SparePartsDetailsModel>();
            Bid_HandsetDetailsModel = new Bid_HandsetDetailsModel();
            Bid_HandsetDetailsModels = new List<Bid_HandsetDetailsModel>();
            Bid_HandsetDetailsModel1 = new Bid_HandsetDetailsModel();
            Bid_HandsetDetailsModels1 = new List<Bid_HandsetDetailsModel>();
        }
        public List<Bid_CreateBidModel> CreateBidModels { get; set; }
        public Bid_CreateBidModel CreateBidModel { get; set; }
        public Bid_SparePartsDetailsModel Bid_SparePartsDetailsModel1 { get; set; }
        public List<Bid_SparePartsDetailsModel> Bid_SparePartsDetailsModels1 { get; set; }
        public Bid_SparePartsDetailsModel Bid_SparePartsDetailsModel { get; set; }
        public List<Bid_SparePartsDetailsModel> Bid_SparePartsDetailsModels { get; set; }
        public List<Bid_HandsetDetailsModel> Bid_HandsetDetailsModels { get; set; }
        public Bid_HandsetDetailsModel Bid_HandsetDetailsModel { get; set; }
        public List<Bid_HandsetDetailsModel> Bid_HandsetDetailsModels1 { get; set; }
        public Bid_HandsetDetailsModel Bid_HandsetDetailsModel1 { get; set; }
    }
}