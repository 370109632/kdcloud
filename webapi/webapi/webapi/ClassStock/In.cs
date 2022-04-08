using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStock
{
    public class In
    {
        public string InsertIn(string _kjson)
        {
            Rootobject _hjson = JsonConvert.DeserializeObject<Rootobject>(_kjson);


            string _sqlstr = string.Format(" insert into PRD_INSTOCK (FID,FENTRYID,FBILLNO,FTYPE,FSTOCK,FWORKSHOP,FMATERIALID,FNUMBER,FNAME,FMODEL,FINTYPE,FUNIT,FYQTY,FSQTY,FSTATUS,FINDATE,FMUNIT,FMQTY,FFUNIT,FFQTY) ");

            string _str = "";

            string Fid = _hjson.ResultX.Result.Id.ToString();

            string FBILLNO = _hjson.ResultX.Result.BillNo;

            Entity[] _entry = _hjson.ResultX.Result.Entity;

            

            for (int i = 0; i < _entry.Length; i++)
            {
                if (_str != "")
                {
                    _str += "  union all ";
                }

                Name7[] _name = _entry[i].MaterialId.Name;


                _str += string.Format(@" select {0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}' ",
                    Fid,  
                    _entry[i].Id.ToString(), 
                    FBILLNO, 
                    _hjson.ResultX.Result.BillType.MultiLanguageText[0].Name, 
                    _entry[i].StockId.Name[0].Value,
                    _entry[i].WorkShopId.MultiLanguageText[0].Name,
                    _entry[i].MaterialId.Id.ToString(), 
                    _entry[i].MaterialId.Number, 
                    _name[0].Value, 
                    _entry[i].MaterialId.Specification[0].Value,
                    _entry[i].InStockType,
                    _entry[i].MaterialId.MaterialBase[0].BaseUnitId.Name[0].Value, 
                    _entry[i].MustQty.ToString(), 
                    _entry[i].RealQty.ToString(),
                    GetStatusName(_hjson.ResultX.Result.DocumentStatus),
                    _hjson.ResultX.Result.Date,
                    _entry[i].StockUnitId.Name[0].Value, 
                    _entry[i].StockRealQty.ToString(),
                    _entry[i].StockUnitId.Name[0].Value,
                    _entry[i].StockRealQty.ToString()


                    );
            }


            _sqlstr = _sqlstr + _str;

            return _sqlstr;
        }

        public string MoXBillNo(string _kjson)
        {
            Rootobject _hjson = JsonConvert.DeserializeObject<Rootobject>(_kjson);

            string FBILLNO = _hjson.ResultX.Result.BillNo;

            return FBILLNO;
        }

        public string GetStatusName(string name)
        {
            switch (name)
            {
                case "A":
                    return "创建";
                case "B":
                    return "审核中";
                case "C":
                    return "已审核";
                case "D":
                    return "重新审核";
                case "Z":
                    return "暂存";
            }

            return name;
        }
    }


    public class Rootobject
    {
        public Resultx ResultX { get; set; }
    }

    public class Resultx
    {
        public Responsestatus ResponseStatus { get; set; }
        public Result Result { get; set; }
    }

    public class Responsestatus
    {
        public bool IsSuccess { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public string FFormId { get; set; }
        public string BillNo { get; set; }
        public string DocumentStatus { get; set; }
        public int ApproverId_Id { get; set; }
        public Approverid ApproverId { get; set; }
        public DateTime ApproveDate { get; set; }
        public int ModifierId_Id { get; set; }
        public Modifierid ModifierId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatorId_Id { get; set; }
        public Creatorid CreatorId { get; set; }
        public DateTime ModifyDate { get; set; }
        public object CancelDate { get; set; }
        public int CANCELER_Id { get; set; }
        public object CANCELER { get; set; }
        public string CancelStatus { get; set; }
        public object[] MultiLanguageText { get; set; }
        public object[] Description { get; set; }
        public DateTime Date { get; set; }
        public int PrdOrgId_Id { get; set; }
        public Prdorgid PrdOrgId { get; set; }
        public string BillType_Id { get; set; }
        public Billtype BillType { get; set; }
        public int StockOrgId_Id { get; set; }
        public Stockorgid StockOrgId { get; set; }
        public int WorkShopId_Id { get; set; }
        public object WorkShopId { get; set; }
        public int StockId_Id { get; set; }
        public object StockId { get; set; }
        public string OwnerTypeId { get; set; }
        public int OwnerId_Id { get; set; }
        public Ownerid OwnerId { get; set; }
        public int CurrId_Id { get; set; }
        public Currid CurrId { get; set; }
        public int FSTOCKERID_Id { get; set; }
        public object FSTOCKERID { get; set; }
        public int FIOSBizTypeId_Id { get; set; }
        public Fiosbiztypeid FIOSBizTypeId { get; set; }
        public bool IsEntrust { get; set; }
        public int EntrustInStockId { get; set; }
        public bool IsIOSForFin { get; set; }
        public object ScanBox { get; set; }
        public bool ISGENFORIOS { get; set; }
        public Entity[] Entity { get; set; }
        public object BOS_ConvertTakeDataInfo { get; set; }
    }

    public class Approverid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
    }

    public class Modifierid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
    }

    public class Creatorid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
    }

    public class Prdorgid
    {
        public int Id { get; set; }
        public Multilanguagetext[] MultiLanguageText { get; set; }
        public Name[] Name { get; set; }
        public string Number { get; set; }
    }

    public class Multilanguagetext
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Billtype
    {
        public string Id { get; set; }
        public Multilanguagetext1[] MultiLanguageText { get; set; }
        public Name1[] Name { get; set; }
        public string Number { get; set; }
    }

    public class Multilanguagetext1
    {
        public string PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name1
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Stockorgid
    {
        public int Id { get; set; }
        public Multilanguagetext2[] MultiLanguageText { get; set; }
        public Name2[] Name { get; set; }
        public string Number { get; set; }
    }

    public class Multilanguagetext2
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name2
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Ownerid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext3[] MultiLanguageText { get; set; }
        public Name3[] Name { get; set; }
        public string Number { get; set; }
    }

    public class Multilanguagetext3
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name3
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Currid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext4[] MultiLanguageText { get; set; }
        public Name4[] Name { get; set; }
        public string Number { get; set; }
        public string Sysmbol { get; set; }
        public int PriceDigits { get; set; }
        public int AmountDigits { get; set; }
        public bool IsShowCSymbol { get; set; }
        public string FormatOrder { get; set; }
        public string RoundType { get; set; }
    }

    public class Multilanguagetext4
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name4
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Fiosbiztypeid
    {
        public int Id { get; set; }
        public Multilanguagetext5[] MultiLanguageText { get; set; }
        public Name5[] Name { get; set; }
        public string Number { get; set; }
    }

    public class Multilanguagetext5
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name5
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Entity
    {
        public int Id { get; set; }
        public int Seq { get; set; }
        public int MaterialId_Id { get; set; }
        public Materialid MaterialId { get; set; }
        public string ProductType { get; set; }
        public string InStockType { get; set; }
        public int FUnitID_Id { get; set; }
        public Funitid FUnitID { get; set; }
        public int BaseUnitId_Id { get; set; }
        public Baseunitid1 BaseUnitId { get; set; }
        public float MustQty { get; set; }
        public float BaseMustQty { get; set; }
        public float RealQty { get; set; }
        public float BaseRealQty { get; set; }
        public string OwnerTypeId { get; set; }
        public int OwnerId_Id { get; set; }
        public Ownerid1 OwnerId { get; set; }
        public int StockId_Id { get; set; }
        public Stockid StockId { get; set; }
        public int StockLocId_Id { get; set; }
        public object StockLocId { get; set; }
        public int BomId_Id { get; set; }
        public object BomId { get; set; }
        public int Lot_Id { get; set; }
        public Lot Lot { get; set; }
        public string Lot_Text { get; set; }
        public int AuxpropId_Id { get; set; }
        public object AuxpropId { get; set; }
        public string MtoNo { get; set; }
        public string ProjectNo { get; set; }
        public int WorkShopId_Id { get; set; }
        public Workshopid WorkShopId { get; set; }
        public string MoBillNo { get; set; }
        public int MoId { get; set; }
        public int MoEntryId { get; set; }
        public int MoEntrySeq { get; set; }
        public object[] MultiLanguageText { get; set; }
        public object[] Memo { get; set; }
        public int StockUnitId_Id { get; set; }
        public Stockunitid StockUnitId { get; set; }
        public float StockRealQty { get; set; }
        public int SecUnitId_Id { get; set; }
        public object SecUnitId { get; set; }
        public float SecRealQty { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
        public int SrcInterId { get; set; }
        public int SrcEntryId { get; set; }
        public int SrcEntrySeq { get; set; }
        public int StockStatusId_Id { get; set; }
        public Stockstatusid StockStatusId { get; set; }
        public string KeeperTypeId { get; set; }
        public int KeeperId_Id { get; set; }
        public Keeperid KeeperId { get; set; }
        public object ProduceDate { get; set; }
        public object ExpiryDate { get; set; }
        public bool StockFlag { get; set; }
        public string SrcBillType { get; set; }
        public string SrcBillNo { get; set; }
        public string BFLowId_Id { get; set; }
        public Bflowid BFLowId { get; set; }
        public int ShiftGroupId_Id { get; set; }
        public object ShiftGroupId { get; set; }
        public int SNUnitId_Id { get; set; }
        public object SNUnitId { get; set; }
        public float SNQty { get; set; }
        public bool CheckProduct { get; set; }
        public string QAIP { get; set; }
        public float COSTRATE { get; set; }
        public bool IsNew { get; set; }
        public bool IsFinished { get; set; }
        public bool ISBACKFLUSH { get; set; }
        public int MoMainEntryId { get; set; }
        public float BasePrdRealQty { get; set; }
        public string ReqSrc { get; set; }
        public string ReqBillNo { get; set; }
        public int ReqBillId { get; set; }
        public int ReqEntrySeq { get; set; }
        public int ReqEntryId { get; set; }
        public float SelReStkQty { get; set; }
        public float BaseSelReStkQty { get; set; }
        public string SrcBusinessType { get; set; }
        public object SendRowId { get; set; }
        public bool IsOverLegalOrg { get; set; }
        public object[] PRD_INSTOCKMTRLSERIAL { get; set; }
        public Fentity_Link[] FEntity_Link { get; set; }
    }

    public class Materialid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext7[] MultiLanguageText { get; set; }
        public Name7[] Name { get; set; }
        public string Number { get; set; }
        public int UseOrgId_Id { get; set; }
        public Useorgid UseOrgId { get; set; }
        public Specification[] Specification { get; set; }
        public Materialbase[] MaterialBase { get; set; }
        public Materialstock[] MaterialStock { get; set; }
        public Materialplan[] MaterialPlan { get; set; }
        public Materialproduce[] MaterialProduce { get; set; }
        public Materialauxpty[] MaterialAuxPty { get; set; }
        public Materialinvpty[] MaterialInvPty { get; set; }
        public Materialqm[] MaterialQM { get; set; }
    }

    public class Useorgid
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Multilanguagetext6[] MultiLanguageText { get; set; }
        public Name6[] Name { get; set; }
    }

    public class Multilanguagetext6
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name6
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Multilanguagetext7
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
    }

    public class Name7
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Specification
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Materialbase
    {
        public int Id { get; set; }
        public string ErpClsID { get; set; }
        public int BaseUnitId_Id { get; set; }
        public Baseunitid BaseUnitId { get; set; }
    }

    public class Baseunitid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext8[] MultiLanguageText { get; set; }
        public Name8[] Name { get; set; }
    }

    public class Multilanguagetext8
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name8
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Materialstock
    {
        public int Id { get; set; }
        public int StoreUnitID_Id { get; set; }
        public Storeunitid StoreUnitID { get; set; }
        public int AuxUnitID_Id { get; set; }
        public object AuxUnitID { get; set; }
        public string ExpUnit { get; set; }
        public int ExpPeriod { get; set; }
        public bool IsBatchManage { get; set; }
        public bool IsKFPeriod { get; set; }
        public bool IsExpParToFlot { get; set; }
        public bool IsSNManage { get; set; }
        public int SNCodeRule_Id { get; set; }
        public object SNCodeRule { get; set; }
        public int SNUnit_Id { get; set; }
        public object SNUnit { get; set; }
        public string UnitConvertDir { get; set; }
        public string SNGenerateTime { get; set; }
        public string SNManageType { get; set; }
    }

    public class Storeunitid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext9[] MultiLanguageText { get; set; }
        public Name9[] Name { get; set; }
    }

    public class Multilanguagetext9
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name9
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Materialplan
    {
        public int Id { get; set; }
        public int MfgPolicyId_Id { get; set; }
        public Mfgpolicyid MfgPolicyId { get; set; }
    }

    public class Mfgpolicyid
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Multilanguagetext10[] MultiLanguageText { get; set; }
        public Name10[] Name { get; set; }
    }

    public class Multilanguagetext10
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name10
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Materialproduce
    {
        public int Id { get; set; }
        public int ProduceUnitId_Id { get; set; }
        public Produceunitid ProduceUnitId { get; set; }
        public float FinishReceiptOverRate { get; set; }
        public float FinishReceiptShortRate { get; set; }
        public string BackFlushType { get; set; }
    }

    public class Produceunitid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext11[] MultiLanguageText { get; set; }
        public Name11[] Name { get; set; }
    }

    public class Multilanguagetext11
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name11
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Materialauxpty
    {
        public int Id { get; set; }
        public bool IsEnable1 { get; set; }
        public bool IsComControl { get; set; }
        public int AuxPropertyId_Id { get; set; }
        public Auxpropertyid AuxPropertyId { get; set; }
    }

    public class Auxpropertyid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext12[] MultiLanguageText { get; set; }
        public Name12[] Name { get; set; }
    }

    public class Multilanguagetext12
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name12
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Materialinvpty
    {
        public int Id { get; set; }
        public bool IsEnable { get; set; }
        public int InvPtyId_Id { get; set; }
        public Invptyid InvPtyId { get; set; }
    }

    public class Invptyid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext13[] MultiLanguageText { get; set; }
        public Name13[] Name { get; set; }
    }

    public class Multilanguagetext13
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name13
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Materialqm
    {
        public int Id { get; set; }
        public bool CheckProduct { get; set; }
    }

    public class Funitid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext15[] MultiLanguageText { get; set; }
        public Name15[] Name { get; set; }
        public string Number { get; set; }
        public int UnitGroupId_Id { get; set; }
        public Unitgroupid UnitGroupId { get; set; }
        public int Precision { get; set; }
        public string RoundType { get; set; }
        public UNITCONVERTRATE[] UNITCONVERTRATE { get; set; }
    }

    public class Unitgroupid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext14[] MultiLanguageText { get; set; }
        public Name14[] Name { get; set; }
    }

    public class Multilanguagetext14
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name14
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Multilanguagetext15
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name15
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class UNITCONVERTRATE
    {
        public int Id { get; set; }
        public string ConvertType { get; set; }
        public int DestUnitId_Id { get; set; }
        public Destunitid DestUnitId { get; set; }
        public int CurrentUnitId_Id { get; set; }
        public Currentunitid CurrentUnitId { get; set; }
        public float ConvertDenominator { get; set; }
        public float ConvertNumerator { get; set; }
    }

    public class Destunitid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext16[] MultiLanguageText { get; set; }
        public Name16[] Name { get; set; }
    }

    public class Multilanguagetext16
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name16
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Currentunitid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext17[] MultiLanguageText { get; set; }
        public Name17[] Name { get; set; }
    }

    public class Multilanguagetext17
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name17
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Baseunitid1
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext19[] MultiLanguageText { get; set; }
        public Name19[] Name { get; set; }
        public string Number { get; set; }
        public int UnitGroupId_Id { get; set; }
        public Unitgroupid1 UnitGroupId { get; set; }
        public int Precision { get; set; }
        public string RoundType { get; set; }
        public UNITCONVERTRATE1[] UNITCONVERTRATE { get; set; }
    }

    public class Unitgroupid1
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext18[] MultiLanguageText { get; set; }
        public Name18[] Name { get; set; }
    }

    public class Multilanguagetext18
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name18
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Multilanguagetext19
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name19
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class UNITCONVERTRATE1
    {
        public int Id { get; set; }
        public string ConvertType { get; set; }
        public int DestUnitId_Id { get; set; }
        public Destunitid1 DestUnitId { get; set; }
        public int CurrentUnitId_Id { get; set; }
        public Currentunitid1 CurrentUnitId { get; set; }
        public float ConvertDenominator { get; set; }
        public float ConvertNumerator { get; set; }
    }

    public class Destunitid1
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext20[] MultiLanguageText { get; set; }
        public Name20[] Name { get; set; }
    }

    public class Multilanguagetext20
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name20
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Currentunitid1
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext21[] MultiLanguageText { get; set; }
        public Name21[] Name { get; set; }
    }

    public class Multilanguagetext21
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name21
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Ownerid1
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext22[] MultiLanguageText { get; set; }
        public Name22[] Name { get; set; }
        public string Number { get; set; }
    }

    public class Multilanguagetext22
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name22
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Stockid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext24[] MultiLanguageText { get; set; }
        public Name24[] Name { get; set; }
        public string Number { get; set; }
        public bool IsOpenLocation { get; set; }
        public string StockStatusType { get; set; }
        public int DefStockStatusId_Id { get; set; }
        public Defstockstatusid DefStockStatusId { get; set; }
        public object[] StockFlexItem { get; set; }
    }

    public class Defstockstatusid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext23[] MultiLanguageText { get; set; }
        public Name23[] Name { get; set; }
    }

    public class Multilanguagetext23
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name23
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Multilanguagetext24
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name24
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Lot
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext25[] MultiLanguageText { get; set; }
        public Name25[] Name { get; set; }
        public string Number { get; set; }
        public string BizType { get; set; }
        public object HProduceDate { get; set; }
        public object HExpiryDate { get; set; }
    }

    public class Multilanguagetext25
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name25
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Workshopid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext26[] MultiLanguageText { get; set; }
        public Name26[] Name { get; set; }
        public string Number { get; set; }
    }

    public class Multilanguagetext26
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name26
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Stockunitid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext28[] MultiLanguageText { get; set; }
        public Name28[] Name { get; set; }
        public string Number { get; set; }
        public int UnitGroupId_Id { get; set; }
        public Unitgroupid2 UnitGroupId { get; set; }
        public int Precision { get; set; }
        public string RoundType { get; set; }
        public UNITCONVERTRATE2[] UNITCONVERTRATE { get; set; }
    }

    public class Unitgroupid2
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext27[] MultiLanguageText { get; set; }
        public Name27[] Name { get; set; }
    }

    public class Multilanguagetext27
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name27
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Multilanguagetext28
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name28
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class UNITCONVERTRATE2
    {
        public int Id { get; set; }
        public string ConvertType { get; set; }
        public int DestUnitId_Id { get; set; }
        public Destunitid2 DestUnitId { get; set; }
        public int CurrentUnitId_Id { get; set; }
        public Currentunitid2 CurrentUnitId { get; set; }
        public float ConvertDenominator { get; set; }
        public float ConvertNumerator { get; set; }
    }

    public class Destunitid2
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext29[] MultiLanguageText { get; set; }
        public Name29[] Name { get; set; }
    }

    public class Multilanguagetext29
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name29
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Currentunitid2
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext30[] MultiLanguageText { get; set; }
        public Name30[] Name { get; set; }
    }

    public class Multilanguagetext30
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name30
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Stockstatusid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext31[] MultiLanguageText { get; set; }
        public Name31[] Name { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
    }

    public class Multilanguagetext31
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name31
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Keeperid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext32[] MultiLanguageText { get; set; }
        public Name32[] Name { get; set; }
        public string Number { get; set; }
    }

    public class Multilanguagetext32
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name32
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Bflowid
    {
        public string Id { get; set; }
        public Multilanguagetext33[] MultiLanguageText { get; set; }
        public Name33[] Name { get; set; }
    }

    public class Multilanguagetext33
    {
        public string PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    public class Name33
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class Fentity_Link
    {
        public int Id { get; set; }
        public string FlowId { get; set; }
        public int FlowLineId { get; set; }
        public string RuleId { get; set; }
        public int STableId { get; set; }
        public string STableName { get; set; }
        public string SBillId { get; set; }
        public string SId { get; set; }
        public float BasePrdRealQtyOld { get; set; }
        public float BasePrdRealQty { get; set; }
    }

}
