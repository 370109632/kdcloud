using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Data;

namespace webapi
{
    public class InserMo
    {


        public string InserMoX(string _kjson)
        {
            Rootobject _hjson = JsonConvert.DeserializeObject<Rootobject>(_kjson);


            string _sqlstr = string.Format(" insert into t_prd_mo (FID,FBILLNO,FENTRYID,FMATERIALID,FNUMBER,FNAME,FMODEL,FUNITID,FQTY,FBTIME,FETIME,FUPQTY,FDOWNQTY,FPASSQTY,FNOQTY,FKLQTY) ");

            string _str = "";

            string Fid = _hjson.ResultX.Result.Id.ToString();

            string FBILLNO = _hjson.ResultX.Result.BillNo;

            Treeentity[] _entry = _hjson.ResultX.Result.TreeEntity;


            for (int i = 0; i < _entry.Length; i++)
            {
                if (_str != "")
                {
                    _str += "  union all ";
                }

                Name5[] _name = _entry[i].MaterialId.Name;


                _str += string.Format(@" select {0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}' ",
                    Fid, FBILLNO, _entry[i].Id.ToString(), _entry[i].MaterialId.Id.ToString(), _entry[i].MaterialId.Number, _name[0].Value, _entry[i].MaterialId.Specification[0].Value,
                    _entry[i].MaterialId.MaterialBase[0].BaseUnitId.Name[0].Value, _entry[i].Qty,_entry[i].PlanStartDate, _entry[i].PlanFinishDate, _entry[i].StockInLimitH, _entry[i].StockInLimitL,
                    _entry[i].StockInQuaAuxQty, _entry[i].StockInFailAuxQty, _entry[i].StockInScrapQty


                    );
            }


            _sqlstr = _sqlstr + _str;

            return _sqlstr;
        }

        

    }



    class Rootobject
    {
        public ResultX ResultX { get; set; }
    }

    class ResultX
    {
        public Responsestatus ResponseStatus { get; set; }
        public Result1 Result { get; set; }
    }

    class Responsestatus
    {
        public bool IsSuccess { get; set; }
    }

    class Result1
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
        public string BillType_Id { get; set; }
        public Billtype BillType { get; set; }
        public bool Trustteed { get; set; }
        public int WorkShopID_Id { get; set; }
        public object WorkShopID { get; set; }
        public int PrdOrgId_Id { get; set; }
        public Prdorgid PrdOrgId { get; set; }
        public int PlannerID_Id { get; set; }
        public object PlannerID { get; set; }
        public DateTime Date { get; set; }
        public string OwnerTypeId { get; set; }
        public int OwnerId_Id { get; set; }
        public Ownerid OwnerId { get; set; }
        public int WorkGroupId_Id { get; set; }
        public object WorkGroupId { get; set; }
        public string BusinessType { get; set; }
        public bool IsRework { get; set; }
        public bool IsEntrust { get; set; }
        public int ENTrustOrgId_Id { get; set; }
        public object ENTrustOrgId { get; set; }
        public string PPBOMType { get; set; }
        public bool IssueMtrl { get; set; }
        public bool IsQCMO { get; set; }
        public Treeentity[] TreeEntity { get; set; }
        public object[] ScheduledEntity { get; set; }
        public object BOS_ConvertTakeDataInfo { get; set; }
    }

    class Approverid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
    }

    class Modifierid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
    }

    class Creatorid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
    }

    class Billtype
    {
        public string Id { get; set; }
        public Multilanguagetext[] MultiLanguageText { get; set; }
        public Name[] Name { get; set; }
        public string Number { get; set; }
    }

    class Multilanguagetext
    {
        public string PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Prdorgid
    {
        public int Id { get; set; }
        public Multilanguagetext1[] MultiLanguageText { get; set; }
        public Name1[] Name { get; set; }
        public string Number { get; set; }
    }

    class Multilanguagetext1
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name1
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Ownerid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext2[] MultiLanguageText { get; set; }
        public Name2[] Name { get; set; }
        public string Number { get; set; }
    }

    class Multilanguagetext2
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name2
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Treeentity
    {
        public int Id { get; set; }
        public int Seq { get; set; }
        public string ParentRowId { get; set; }
        public int RowExpandType { get; set; }
        public string RowId { get; set; }
        public int MaterialId_Id { get; set; }
        public Materialid MaterialId { get; set; }
        public string ProductType { get; set; }
        public float Qty { get; set; }
        public DateTime PlanFinishDate { get; set; }
        public DateTime PlanStartDate { get; set; }
        public int Lot_Id { get; set; }
        public object Lot { get; set; }
        public string Lot_Text { get; set; }
        public string MTONo { get; set; }
        public string ProjectNo { get; set; }
        public float BaseUnitQty { get; set; }
        public int Group { get; set; }
        public int BomId_Id { get; set; }
        public Bomid BomId { get; set; }
        public int RoutingId_Id { get; set; }
        public object RoutingId { get; set; }
        public float YieldRate { get; set; }
        public float StockInLimitH { get; set; }
        public float StockInLimitL { get; set; }
        public float StockInQuaSelAuxQty { get; set; }
        public float StockInQuaSelQty { get; set; }
        public float StockInFailSelQty { get; set; }
        public float StockInFailSelAuxQty { get; set; }
        public float StockInQuaQty { get; set; }
        public float StockInQuaAuxQty { get; set; }
        public float StockInFailQty { get; set; }
        public float StockInFailAuxQty { get; set; }
        public int StockInOrgId_Id { get; set; }
        public Stockinorgid StockInOrgId { get; set; }
        public int StockId_Id { get; set; }
        public object StockId { get; set; }
        public int StockLocId_Id { get; set; }
        public object StockLocId { get; set; }
        public int OperId { get; set; }
        public int ProcessId_Id { get; set; }
        public object ProcessId { get; set; }
        public float CostRate { get; set; }
        public Multilanguagetext22[] MultiLanguageText { get; set; }
        public Memo[] Memo { get; set; }
        public DateTime PlanConfirmDate { get; set; }
        public object ScheduleDate { get; set; }
        public DateTime ConveyDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime CloseDate { get; set; }
        public object CostDate { get; set; }
        public string CreateType { get; set; }
        public int SrcBillId { get; set; }
        public int SrcBillEntryId { get; set; }
        public int SaleOrderId { get; set; }
        public string SaleOrderNo { get; set; }
        public int SaleOrderEntryId { get; set; }
        public int RequestOrgId_Id { get; set; }
        public Requestorgid RequestOrgId { get; set; }
        public float RepQuaSelQty { get; set; }
        public float RepFailQty { get; set; }
        public float RepQuaSelAuxQty { get; set; }
        public float RepQuaAuxQty { get; set; }
        public float RepFailAuxQty { get; set; }
        public float RepQuaQty { get; set; }
        public string Status { get; set; }
        public int UnitId_Id { get; set; }
        public Unitid UnitId { get; set; }
        public int BaseUnitId_Id { get; set; }
        public Baseunitid1 BaseUnitId { get; set; }
        public int AuxPropId_Id { get; set; }
        public object AuxPropId { get; set; }
        public float BaseStockInLimitH { get; set; }
        public float BaseStockInLimitL { get; set; }
        public float StockInUlRatio { get; set; }
        public string SrcBillType { get; set; }
        public string SrcBillNo { get; set; }
        public int SrcBillEntrySeq { get; set; }
        public int SaleOrderEntrySeq { get; set; }
        public float BaseYieldQty { get; set; }
        public int CopyEntryId { get; set; }
        public string IsSuspend { get; set; }
        public float StockInLlRatio { get; set; }
        public string BFLowId_Id { get; set; }
        public Bflowid BFLowId { get; set; }
        public float RepFailSelQty { get; set; }
        public float RepFailSelAuxQty { get; set; }
        public int WorkShopID_Id { get; set; }
        public Workshopid WorkShopID { get; set; }
        public string ReqType { get; set; }
        public int Priority { get; set; }
        public float StockReady { get; set; }
        public float BaseStockReady { get; set; }
        public float BaseScrapQty { get; set; }
        public float ScrapQty { get; set; }
        public float BaseRepairQty { get; set; }
        public float RepairQty { get; set; }
        public float BaseStockInScrapSelQty { get; set; }
        public float StockInScrapSelQty { get; set; }
        public float BaseStockInScrapQty { get; set; }
        public float StockInScrapQty { get; set; }
        public string InStockOwnerTypeId { get; set; }
        public int InStockOwnerId_Id { get; set; }
        public Instockownerid InStockOwnerId { get; set; }
        public string InStockType { get; set; }
        public bool CheckProduct { get; set; }
        public string OutPutOptQueue { get; set; }
        public float BaseRptFinishQty { get; set; }
        public float RptFinishQty { get; set; }
        public string QAIP { get; set; }
        public float YieldQty { get; set; }
        public bool ISBACKFLUSH { get; set; }
        public float NoStockInQty { get; set; }
        public float BaseNoStockInQty { get; set; }
        public string ReqSrc { get; set; }
        public int ForceCloserId_Id { get; set; }
        public Forcecloserid ForceCloserId { get; set; }
        public int REMWorkShopId_Id { get; set; }
        public object REMWorkShopId { get; set; }
        public float ScheduleSeq { get; set; }
        public object ScheduleStartTime { get; set; }
        public object ScheduleFinishTime { get; set; }
        public string CloseType { get; set; }
        public int ScheduleProcSplit { get; set; }
        public int SNUnitID_Id { get; set; }
        public object SNUnitID { get; set; }
        public float SNQty { get; set; }
        public float ReStkQty { get; set; }
        public float BaseReStkQty { get; set; }
        public float ReStkQuaQty { get; set; }
        public float BaseReStkQuaQty { get; set; }
        public float ReStkFailQty { get; set; }
        public float BaseReStkFailQty { get; set; }
        public float ReStkScrapQty { get; set; }
        public float BaseReStkScrapQty { get; set; }
        public float PickMtlQty { get; set; }
        public float BasePickMtlQty { get; set; }
        public int ISNEWLC { get; set; }
        public string PickMtrlStatus { get; set; }
        public float BaseIssueQty { get; set; }
        public float IssueQty { get; set; }
        public string SrcSplitBillNo { get; set; }
        public int SrcSplitSeq { get; set; }
        public int SrcSplitEntryId { get; set; }
        public int SrcSplitId { get; set; }
        public bool MOChangeFlag { get; set; }
        public int SrcBomEntryId { get; set; }
        public float ReStkReMadeQty { get; set; }
        public float BaseReStkReMadeQty { get; set; }
        public float BaseReMadeQty { get; set; }
        public float ReMadeQty { get; set; }
        public float BaseStockInReMadeQty { get; set; }
        public float StockInReMadeQty { get; set; }
        public float BaseStockInReMadeSelQty { get; set; }
        public float StockInReMadeSelQty { get; set; }
        public Closereason[] CloseReason { get; set; }
        public float BaseScheduledQtySum { get; set; }
        public float ScheduledQtySum { get; set; }
        public string ScheduleStatus { get; set; }
        public bool IsFirstInspect { get; set; }
        public string FirstInspectStatus { get; set; }
        public int ConfirmId_Id { get; set; }
        public Confirmid ConfirmId { get; set; }
        public int ReleaseId_Id { get; set; }
        public Releaseid ReleaseId { get; set; }
        public int StartID_Id { get; set; }
        public Startid StartID { get; set; }
        public int FinishId_Id { get; set; }
        public Finishid FinishId { get; set; }
        public bool IsMRP { get; set; }
        public float BaseSampleDamageQty { get; set; }
        public float SampleDamageQty { get; set; }
        public bool ISENABLESCHEDULE { get; set; }
        public string PathEntryId { get; set; }
        public int PPBOMENTRYID { get; set; }
        public int BOMENTRYID { get; set; }
        public string SrcFormID { get; set; }
        public string F_admi_Text { get; set; }
        public object[] SerialSubEntity { get; set; }
        public FTREEENTITY_Link[] FTREEENTITY_Link { get; set; }
    }

    class Materialid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext5[] MultiLanguageText { get; set; }
        public Name5[] Name { get; set; }
        public string Number { get; set; }
        public int UseOrgId_Id { get; set; }
        public Useorgid UseOrgId { get; set; }
        public Specification[] Specification { get; set; }
        public int MaterialGroup_Id { get; set; }
        public Materialgroup MaterialGroup { get; set; }
        public Materialbase[] MaterialBase { get; set; }
        public Materialstock[] MaterialStock { get; set; }
        public Materialplan[] MaterialPlan { get; set; }
        public Materialproduce[] MaterialProduce { get; set; }
        public object[] MaterialAuxPty { get; set; }
        public Materialinvpty[] MaterialInvPty { get; set; }
        public Materialqm[] MaterialQM { get; set; }
    }

    class Useorgid
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Multilanguagetext3[] MultiLanguageText { get; set; }
        public Name3[] Name { get; set; }
    }

    class Multilanguagetext3
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name3
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Materialgroup
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Multilanguagetext4[] MultiLanguageText { get; set; }
        public Name4[] Name { get; set; }
    }

    class Multilanguagetext4
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name4
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Multilanguagetext5
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
    }

    class Name5
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Specification
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Materialbase
    {
        public int Id { get; set; }
        public string ErpClsID { get; set; }
        public bool IsInventory { get; set; }
        public int BaseUnitId_Id { get; set; }
        public Baseunitid BaseUnitId { get; set; }
    }

    class Baseunitid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext6[] MultiLanguageText { get; set; }
        public Name6[] Name { get; set; }
    }

    class Multilanguagetext6
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name6
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Materialstock
    {
        public int Id { get; set; }
        public int StoreUnitID_Id { get; set; }
        public Storeunitid StoreUnitID { get; set; }
        public int StockId_Id { get; set; }
        public object StockId { get; set; }
        public int StockPlaceId_Id { get; set; }
        public object StockPlaceId { get; set; }
        public bool IsBatchManage { get; set; }
        public bool IsKFPeriod { get; set; }
        public bool IsExpParToFlot { get; set; }
        public bool IsSNManage { get; set; }
        public int SNCodeRule_Id { get; set; }
        public object SNCodeRule { get; set; }
        public int SNUnit_Id { get; set; }
        public object SNUnit { get; set; }
        public bool IsSNPRDTracy { get; set; }
        public string SNManageType { get; set; }
    }

    class Storeunitid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext7[] MultiLanguageText { get; set; }
        public Name7[] Name { get; set; }
    }

    class Multilanguagetext7
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name7
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Materialplan
    {
        public int Id { get; set; }
        public string PlanningStrategy { get; set; }
        public string FixLeadTimeType { get; set; }
        public int FixLeadTime { get; set; }
        public string VarLeadTimeType { get; set; }
        public int VarLeadTime { get; set; }
        public float VarLeadTimeLotSize { get; set; }
        public int MfgPolicyId_Id { get; set; }
        public Mfgpolicyid MfgPolicyId { get; set; }
    }

    class Mfgpolicyid
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Multilanguagetext8[] MultiLanguageText { get; set; }
        public Name8[] Name { get; set; }
    }

    class Multilanguagetext8
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name8
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Materialproduce
    {
        public int Id { get; set; }
        public int WorkShopId_Id { get; set; }
        public object WorkShopId { get; set; }
        public int ProduceUnitId_Id { get; set; }
        public Produceunitid ProduceUnitId { get; set; }
        public int DefaultRouting_Id { get; set; }
        public object DefaultRouting { get; set; }
        public float PerUnitStandHour { get; set; }
        public float FinishReceiptOverRate { get; set; }
        public float FinishReceiptShortRate { get; set; }
        public bool IsEnableSchedule { get; set; }
    }

    class Produceunitid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext9[] MultiLanguageText { get; set; }
        public Name9[] Name { get; set; }
    }

    class Multilanguagetext9
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name9
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Materialinvpty
    {
        public int Id { get; set; }
        public bool IsAffectPlan { get; set; }
        public int InvPtyId_Id { get; set; }
        public Invptyid InvPtyId { get; set; }
    }

    class Invptyid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext10[] MultiLanguageText { get; set; }
        public Name10[] Name { get; set; }
    }

    class Multilanguagetext10
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name10
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Materialqm
    {
        public int Id { get; set; }
        public bool CheckProduct { get; set; }
        public bool IsFirstInspect { get; set; }
    }

    class Bomid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string ForbidStatus { get; set; }
        public object[] MultiLanguageText { get; set; }
        public object[] Name { get; set; }
        public string Number { get; set; }
        public float YIELDRATE { get; set; }
        public int ParentAuxPropId_Id { get; set; }
        public object ParentAuxPropId { get; set; }
    }

    class Stockinorgid
    {
        public int Id { get; set; }
        public Multilanguagetext11[] MultiLanguageText { get; set; }
        public Name11[] Name { get; set; }
        public string Number { get; set; }
    }

    class Multilanguagetext11
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name11
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Requestorgid
    {
        public int Id { get; set; }
        public Multilanguagetext12[] MultiLanguageText { get; set; }
        public Name12[] Name { get; set; }
        public string Number { get; set; }
    }

    class Multilanguagetext12
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name12
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Unitid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext14[] MultiLanguageText { get; set; }
        public Name14[] Name { get; set; }
        public string Number { get; set; }
        public int UnitGroupId_Id { get; set; }
        public Unitgroupid UnitGroupId { get; set; }
        public int Precision { get; set; }
        public string RoundType { get; set; }
        public UNITCONVERTRATE[] UNITCONVERTRATE { get; set; }
    }

    class Unitgroupid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext13[] MultiLanguageText { get; set; }
        public Name13[] Name { get; set; }
    }

    class Multilanguagetext13
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name13
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Multilanguagetext14
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name14
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class UNITCONVERTRATE
    {
        public int Id { get; set; }
        public string ConvertType { get; set; }
        public float ConvertDenominator { get; set; }
        public float ConvertNumerator { get; set; }
    }

    class Baseunitid1
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext16[] MultiLanguageText { get; set; }
        public Name16[] Name { get; set; }
        public string Number { get; set; }
        public int UnitGroupId_Id { get; set; }
        public Unitgroupid1 UnitGroupId { get; set; }
        public int Precision { get; set; }
        public string RoundType { get; set; }
        public UNITCONVERTRATE1[] UNITCONVERTRATE { get; set; }
    }

    class Unitgroupid1
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public string Number { get; set; }
        public Multilanguagetext15[] MultiLanguageText { get; set; }
        public Name15[] Name { get; set; }
    }

    class Multilanguagetext15
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name15
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Multilanguagetext16
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name16
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class UNITCONVERTRATE1
    {
        public int Id { get; set; }
        public string ConvertType { get; set; }
        public float ConvertDenominator { get; set; }
        public float ConvertNumerator { get; set; }
    }

    class Bflowid
    {
        public string Id { get; set; }
        public Multilanguagetext17[] MultiLanguageText { get; set; }
        public Name17[] Name { get; set; }
    }

    class Multilanguagetext17
    {
        public string PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name17
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Workshopid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext20[] MultiLanguageText { get; set; }
        public Name20[] Name { get; set; }
        public string Number { get; set; }
        public int UseOrgId_Id { get; set; }
        public Useorgid1 UseOrgId { get; set; }
        public string DeptProperty_Id { get; set; }
        public Deptproperty DeptProperty { get; set; }
    }

    class Useorgid1
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Multilanguagetext18[] MultiLanguageText { get; set; }
        public Name18[] Name { get; set; }
    }

    class Multilanguagetext18
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name18
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Deptproperty
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public Multilanguagetext19[] MultiLanguageText { get; set; }
        public Name19[] Name { get; set; }
    }

    class Multilanguagetext19
    {
        public string PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name19
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Multilanguagetext20
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name20
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Instockownerid
    {
        public int Id { get; set; }
        public int msterID { get; set; }
        public Multilanguagetext21[] MultiLanguageText { get; set; }
        public Name21[] Name { get; set; }
        public string Number { get; set; }
    }

    class Multilanguagetext21
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Name { get; set; }
    }

    class Name21
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Forcecloserid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
    }

    class Confirmid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
    }

    class Releaseid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
    }

    class Startid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
    }

    class Finishid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserAccount { get; set; }
    }

    class Multilanguagetext22
    {
        public int PkId { get; set; }
        public int LocaleId { get; set; }
        public string Memo { get; set; }
        public string CloseReason { get; set; }
    }

    class Memo
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class Closereason
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    class FTREEENTITY_Link
    {
        public int Id { get; set; }
        public string FlowId { get; set; }
        public int FlowLineId { get; set; }
        public string RuleId { get; set; }
        public int STableId { get; set; }
        public string STableName { get; set; }
        public string SBillId { get; set; }
        public string SId { get; set; }
        public float BaseUnitQtyOld { get; set; }
        public float BaseUnitQty { get; set; }
        public string FLnkTrackerId { get; set; }
        public string FLnkSState { get; set; }
        public float FLnkAmount { get; set; }
        public string FLnkSeToMoTrackerId { get; set; }
        public string FLnkSeToMoSState { get; set; }
        public float FLnkSeToMoAmount { get; set; }
    }



}
