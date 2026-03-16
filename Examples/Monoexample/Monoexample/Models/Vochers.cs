using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Monoexample.Models
{

    [BsonIgnoreExtraElements]
    public class Vochers
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("VoucherNo")]
        public string? VoucherNo { get; set; }
        public string? VoucherDate { get; set; }
        public string? VoucherType { get; set; }
        public string? ReferenceNo { get; set; }
        public string? REFERENCEDATE { get; set; }
        public string? Guid { get; set; }
        public string? MasterId { get; set; }
        [BsonElement("TLISOPTIONAL")]
        public string? TliOp { get; set; }
        [BsonElement("TLISCANCELLED")]
        public string? tliCancel { get; set; }
       
        public string? PartyName { get; set; }
        public string? ClosingBalance { get; set; }
        [BsonElement("NxPartyCode")]
        public string? NxPartyCode  {get; set;}
        public string? CustomerName {get; set;}
        public string? Amount { get; set; }
        public string?  PARTYGSTIN {get; set;}
        public string?  MobileNumber{get; set;}
        public string? EmailId{ get; set; }
        public string?  BuyerAddress{get; set;}
        [BsonElement("ConsigneeAddress")]
        public string?  CosigneeAdress{get; set;}
        public string?  State {get; set;}
        public string? CREDITLIMIT {get; set;}
        public string?  PlaceOfSupply {get; set;}
        [BsonElement("SpecialDCNote")]
        public string?  SpecialDCNote {get; set;}
        public List<INVOICEDELNOTES> Is { get; set; } = null!;
        public string? Project {  get; set; }


        public List<PaymentTerms>? Payment_Terms { get; set; }
        public List<Orders>? Orders { get; set; }
        public List<Items>? Items { get; set; }
        public List<INVOICEDELNOTES>? InvoiceDelNotes { get; set; }

        public List<object>? Ledger { get; set; }
    }

    public class INVOICEDELNOTES
{
        public string? BASICSHIPDELIVERYNOTE { get; set; }
        public string? BASICSHIPPINGDATE { get; set; }

    }

    [BsonIgnoreExtraElements]
    public class PaymentTerms
    {
        [BsonElement("Terms")]
        public string? terms { get; set; }
    }
    [BsonIgnoreExtraElements]
    
    
    public class Items
    {
        [BsonElement("OrderNo")]
        public string? OrderNo { get; set; }
        public string?NxItemCode { get; set;}
        public string? PartNo { get; set;}
        public string? OrderDue{ get; set; }
        public string? ItemName{ get; set; } 
        public string? BaseUnits{ get; set; }
        public string? ActualQty{ get; set; }
        public string?BilledQty{ get; set; }
        public string? InclRate{ get; set; }
        public string? Rate{ get; set; }
        public string? DiscPerc{ get; set; }
        public string?Amount{ get; set; }
        public string?AccountingName{ get; set; }
        public string?GstPer{ get; set; }
        [BsonElement("Description")]
        public IEnumerable<Description>? descriptions { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Description
    {
        [BsonElement("Desc")]
        public string? Desc { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Orders
    {
        [BsonElement("OrderId")]
        public string? OrdersId { get; set; }
        [BsonElement("ORDERDATE")]
        public string? dateTime { get; set; }
    }
    
}
