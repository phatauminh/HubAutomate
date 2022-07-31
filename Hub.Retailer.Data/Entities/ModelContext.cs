using Hub.Retailer.Common.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Hub.Retailer.Data.Entities
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventException> EventException { get; set; }
        public virtual DbSet<EventExceptionDetail> EventExceptionDetail { get; set; }
        public virtual DbSet<EventStore> EventStore { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle(RetailerConfiguration.DatabaseSettings.ConnectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventException>(entity =>
            {
                entity.HasKey(e => e.Exceptionid)
                    .HasName("PKEVENTEXCEPTIONS");

                entity.ToTable("EVENTEXCEPTION");

                entity.HasIndex(e => e.CreatedDate)
                    .HasName("IDX2EVENTEXCEPTIONS");

                entity.HasIndex(e => e.Eventid)
                    .HasName("IDX3EVENTEXCEPTIONS");

                entity.HasIndex(e => e.ExceptionExternalEventId)
                    .HasName("IDX1EVENTEXCEPTIONS");

                entity.Property(e => e.Exceptionid)
                    .HasColumnName("EXCEPTIONID")
                    .HasColumnType("NUMBER(15)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATEDDATE")
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("SYSDATE ");

                entity.Property(e => e.Eventid)
                    .HasColumnName("EVENTID")
                    .HasColumnType("NUMBER(15)");

                entity.Property(e => e.ExceptionExternalEventId)
                    .IsRequired()
                    .HasColumnName("EXCEPTIONEXTERNALEVENTID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionHeader)
                    .HasColumnName("EXCEPTIONHEADER")
                    .HasColumnType("CLOB");

                entity.Property(e => e.ExceptionPayload)
                    .IsRequired()
                    .HasColumnName("EXCEPTIONPAYLOAD")
                    .HasColumnType("CLOB");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("CHAR(1)")
                    .HasDefaultValueSql("'0' ");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventException)
                    .HasForeignKey(d => d.Eventid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1EVENTEXCEPTIONS");
            });

            modelBuilder.Entity<EventExceptionDetail>(entity =>
            {
                entity.HasKey(e => e.ExceptionDetailId)
                    .HasName("PKEVENTEXCEPTIONDETAIL");

                entity.ToTable("EVENTEXCEPTIONDETAIL");

                entity.HasIndex(e => e.ExceptionId)
                    .HasName("IDX1EVENTEXCEPTIONDETAIL");

                entity.HasIndex(e => e.Severity)
                    .HasName("IDX2EVENTEXCEPTIONDETAIL");

                entity.HasIndex(e => new { e.Source, e.ExceptionTimestamp })
                    .HasName("IDX3EVENTEXCEPTIONDETAIL");

                entity.Property(e => e.ExceptionDetailId)
                    .HasColumnName("EXCEPTIONDETAILID")
                    .HasColumnType("NUMBER(15)");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CREATEDDATE")
                    .HasColumnType("DATE")
                    .HasDefaultValueSql("SYSDATE ");

                entity.Property(e => e.DetailDescription)
                    .HasColumnName("DETAILDESCRIPTION")
                    .HasColumnType("CLOB");

                entity.Property(e => e.ErrorAttribute)
                    .HasColumnName("ERRORATTRIBUTE")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionEntity)
                    .HasColumnName("EXCEPTIONENTITY")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ExceptionId)
                    .HasColumnName("EXCEPTIONID")
                    .HasColumnType("NUMBER(15)");

                entity.Property(e => e.ExceptionTimestamp)
                    .HasColumnName("EXCEPTIONTIMESTAMP")
                    .HasColumnType("TIMESTAMP(6)")
                    .HasDefaultValueSql("SYSTIMESTAMP ");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("CHAR(1)")
                    .HasDefaultValueSql("'0' ");

                entity.Property(e => e.Severity)
                    .HasColumnName("SEVERITY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasColumnName("SHORTDESCRIPTION")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("SOURCE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exception)
                    .WithMany(p => p.EventExceptionDetail)
                    .HasForeignKey(d => d.ExceptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1EVENTEXCEPTIONDETAIL");
            });

            modelBuilder.Entity<EventStore>(entity =>
            {
                entity.HasKey(e => e.EventId)
                    .HasName("PKEVENTSTORE");

                entity.ToTable("EVENTSTORE");

                entity.HasIndex(e => e.ExternalEventId)
                    .HasName("IDX4EVENTSTORE");

                entity.HasIndex(e => e.ParentEventId)
                    .HasName("IDX3EVENTSTORE");

                entity.HasIndex(e => new { e.Status, e.EventTimestamp })
                    .HasName("IDX1EVENTSTORE");

                entity.HasIndex(e => new { e.EntityId, e.Status, e.EntityType })
                    .HasName("IDX2EVENTSTORE");

                entity.Property(e => e.EventId)
                    .HasColumnName("EVENTID")
                    .HasColumnType("NUMBER(15)");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("ACTION")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EntityId)
                    .HasColumnName("ENTITYID")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.EntityType)
                    .IsRequired()
                    .HasColumnName("ENTITYTYPE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EventPayload)
                    .HasColumnName("EVENTPAYLOAD")
                    .HasColumnType("CLOB");

                entity.Property(e => e.EventSource)
                    .HasColumnName("EVENTSOURCE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EventTimestamp)
                    .HasColumnName("EVENTTIMESTAMP")
                    .HasColumnType("TIMESTAMP(6)")
                    .HasDefaultValueSql("SYSTIMESTAMP ");

                entity.Property(e => e.ExternalEventId)
                    .HasColumnName("EXTERNALEVENTID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MessageHeader)
                    .HasColumnName("MESSAGEHEADER")
                    .HasColumnType("CLOB");

                entity.Property(e => e.ParentEventId)
                    .HasColumnName("PARENTEVENTID")
                    .HasColumnType("NUMBER(15)");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("CHAR(1)")
                    .HasDefaultValueSql("'0' ");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("STATUS")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'PEN' ");
            });

            modelBuilder.HasSequence("ACCUMULATORID");

            modelBuilder.HasSequence("ACTIONDEFINITIONID");

            modelBuilder.HasSequence("ADDRESSID");

            modelBuilder.HasSequence("ADDRESSTEMPLATEID");

            modelBuilder.HasSequence("APDMLOGINEVENTID");

            modelBuilder.HasSequence("APDMSERVICESUBSCRIPTIONID");

            modelBuilder.HasSequence("APDMSUBSCRIPTIONREQUESTID");

            modelBuilder.HasSequence("ARCHIVECONFIGID");

            modelBuilder.HasSequence("ARCHIVEDEPTABLEID");

            modelBuilder.HasSequence("ARCHIVEFILEID");

            modelBuilder.HasSequence("ARCHIVEFILERUNID");

            modelBuilder.HasSequence("ARCHIVEFILERUNITEMID");

            modelBuilder.HasSequence("ARCHIVERUNID");

            modelBuilder.HasSequence("ARCHIVERUNPARTITIONID");

            modelBuilder.HasSequence("ASSETEVENTID");

            modelBuilder.HasSequence("ASSETID");

            modelBuilder.HasSequence("AUDITID");

            modelBuilder.HasSequence("BACSPASSWORDID");

            modelBuilder.HasSequence("BANKID");

            modelBuilder.HasSequence("BGPROPERTYID");

            modelBuilder.HasSequence("BILLINGGROUPID");

            modelBuilder.HasSequence("BILLRULERESULTID");

            modelBuilder.HasSequence("BILLRUNCALENDARID");

            modelBuilder.HasSequence("BILLRUNERRORID");

            modelBuilder.HasSequence("BILLRUNID");

            modelBuilder.HasSequence("BILLRUNREQUESTID");

            modelBuilder.HasSequence("BRINVOCATIONID");

            modelBuilder.HasSequence("BUADDRESSID");

            modelBuilder.HasSequence("BUCONTACTID");

            modelBuilder.HasSequence("BUCPROPERTYID");

            modelBuilder.HasSequence("BUFILTERID");

            modelBuilder.HasSequence("BUFILTERSETID");

            modelBuilder.HasSequence("BUID");

            modelBuilder.HasSequence("BUPROPERTYID");

            modelBuilder.HasSequence("BUPSID");

            modelBuilder.HasSequence("CALENDAREVENTID");

            modelBuilder.HasSequence("CAMPAIGNDETAILID");

            modelBuilder.HasSequence("CAMPAIGNFEEID");

            modelBuilder.HasSequence("CAMPAIGNID");

            modelBuilder.HasSequence("CAMPAIGNMESSAGEID");

            modelBuilder.HasSequence("CAMPAIGNPROPERTYID");

            modelBuilder.HasSequence("CAMPAIGNUTILITYID");

            modelBuilder.HasSequence("CATALOGLAUNCHDETAILID");

            modelBuilder.HasSequence("CATALOGLAUNCHID");

            modelBuilder.HasSequence("CATALOGRECONCILIATIONID");

            modelBuilder.HasSequence("CCCPID");

            modelBuilder.HasSequence("CCEBID");

            modelBuilder.HasSequence("CCEBILLID");

            modelBuilder.HasSequence("CCECHARGECALCREQID");

            modelBuilder.HasSequence("CCEDEMANDID");

            modelBuilder.HasSequence("CCEDETAILID");

            modelBuilder.HasSequence("CCEEVENTID");

            modelBuilder.HasSequence("CCEOVERRIDEID");

            modelBuilder.HasSequence("CCESOFCSEQ");

            modelBuilder.HasSequence("CCESUPPLYPOINTID");

            modelBuilder.HasSequence("CHARGEREDUCTIONTIERID");

            modelBuilder.HasSequence("CLEARINGHOUSEID");

            modelBuilder.HasSequence("CLIENTOBJECTELEMENTID");

            modelBuilder.HasSequence("CLIENTOBJECTID");

            modelBuilder.HasSequence("CLIENTOBJPROPERTYID");

            modelBuilder.HasSequence("CMAUTOID");

            modelBuilder.HasSequence("CMAUTOPROPERTYID");

            modelBuilder.HasSequence("CMFIXEDID");

            modelBuilder.HasSequence("CMFIXEDPROPERTYID");

            modelBuilder.HasSequence("CODETABLELINEID");

            modelBuilder.HasSequence("CODEXLATEID");

            modelBuilder.HasSequence("COMMFILEID");

            modelBuilder.HasSequence("CONSOLEMESSAGEID");

            modelBuilder.HasSequence("CONTROLID");

            modelBuilder.HasSequence("CONVLOADEVENTID");

            modelBuilder.HasSequence("CONVLOADITEMID");

            modelBuilder.HasSequence("CONVUNITID");

            modelBuilder.HasSequence("COUNTRYAPID");

            modelBuilder.HasSequence("CREDITCARDID");

            modelBuilder.HasSequence("CSPROPERTYID");

            modelBuilder.HasSequence("CTLINEPROPERTYID");

            modelBuilder.HasSequence("CUPROPERTYID");

            modelBuilder.HasSequence("CURATESHEETSID");

            modelBuilder.HasSequence("CUSTCOMMSEVENTID");

            modelBuilder.HasSequence("CUSTCOMMSID");

            modelBuilder.HasSequence("CUSTCOMMSPROPERTYID");

            modelBuilder.HasSequence("CUSTCONCESSIONEVENTID");

            modelBuilder.HasSequence("CUSTCONCESSIONID");

            modelBuilder.HasSequence("CUSTGROUPCCHARID");

            modelBuilder.HasSequence("CUSTGROUPZONEID");

            modelBuilder.HasSequence("CUSTOMEREVENTID");

            modelBuilder.HasSequence("CUSTOMERPAYMENTPLANID");

            modelBuilder.HasSequence("CUSTOMERREWARDID");

            modelBuilder.HasSequence("CUSTOMERSITEID");

            modelBuilder.HasSequence("CUSTUPDATEID");

            modelBuilder.HasSequence("CUSTUPDATEMBRID");

            modelBuilder.HasSequence("DAILYDATAAREAID");

            modelBuilder.HasSequence("DAILYDATAID");

            modelBuilder.HasSequence("DAILYTOUVERSIONID");

            modelBuilder.HasSequence("DATAALIASID");

            modelBuilder.HasSequence("DATAITEMMBRID");

            modelBuilder.HasSequence("DATAITEMSETID");

            modelBuilder.HasSequence("DATASOURCEGROUPID");

            modelBuilder.HasSequence("DATASOURCEID");

            modelBuilder.HasSequence("DAUSAGEID");

            modelBuilder.HasSequence("DDBATCHID");

            modelBuilder.HasSequence("DDBPROPERTYID");

            modelBuilder.HasSequence("DDPENDINGID");

            modelBuilder.HasSequence("DDTRANSID");

            modelBuilder.HasSequence("DDTRANSPROPERTYID");

            modelBuilder.HasSequence("DEMANDID");

            modelBuilder.HasSequence("DEPENDANTDOMAINCODEID");

            modelBuilder.HasSequence("DEPOSITID");

            modelBuilder.HasSequence("DEPOSITPROPERTYID");

            modelBuilder.HasSequence("DEPROPERTYID");

            modelBuilder.HasSequence("DICTID");

            modelBuilder.HasSequence("DISCOUNTADJID");

            modelBuilder.HasSequence("DISCOUNTADMINFEEID");

            modelBuilder.HasSequence("DISCOUNTELIGIBILITYID");

            modelBuilder.HasSequence("DISCOUNTPENDINGID");

            modelBuilder.HasSequence("DISCOUNTPLANID");

            modelBuilder.HasSequence("DISETUSAGEID");

            modelBuilder.HasSequence("DOCASSETID");

            modelBuilder.HasSequence("DOCASSETPROPERTYID");

            modelBuilder.HasSequence("DOCASSETRULEID");

            modelBuilder.HasSequence("DOCASSETRULEPROPERTYID");

            modelBuilder.HasSequence("DOCASSETVERSIONID");

            modelBuilder.HasSequence("DOCNBRCREDIT");

            modelBuilder.HasSequence("DOCNBRDEBIT");

            modelBuilder.HasSequence("DOCREQUESTID");

            modelBuilder.HasSequence("DOCREQUESTPROPERTYID");

            modelBuilder.HasSequence("DOCSAMPLEID");

            modelBuilder.HasSequence("DOCUMENTID");

            modelBuilder.HasSequence("DOMAINCODEID");

            modelBuilder.HasSequence("DPPROPERTYID");

            modelBuilder.HasSequence("DPRULEDATASETID");

            modelBuilder.HasSequence("DPTAXCHARGEID");

            modelBuilder.HasSequence("DSPROPERTYID");

            modelBuilder.HasSequence("ECHARGEACCUMID");

            modelBuilder.HasSequence("ECHARGEACCUMTAID");

            modelBuilder.HasSequence("ECHARGECALCTAID");

            modelBuilder.HasSequence("EDDID");

            modelBuilder.HasSequence("EFTJOBID");

            modelBuilder.HasSequence("EFTJOBSETID");

            modelBuilder.HasSequence("ELECNETWORKTARIFFID");

            modelBuilder.HasSequence("ETIMECHARGEID");

            modelBuilder.HasSequence("EVENTEXCEPTIONS_EXCEPTIONID");

            modelBuilder.HasSequence("EVENTHISTORY_EVENTHISTORYID");

            modelBuilder.HasSequence("EVENTSCRIPTID");

            modelBuilder.HasSequence("EVENTSTORE_EVENTID");

            modelBuilder.HasSequence("EXCEPTIONDETAILID");

            modelBuilder.HasSequence("EXCEPTIONEVENTID");

            modelBuilder.HasSequence("EXCEPTIONEVENTPROPERTYID");

            modelBuilder.HasSequence("EXCEPTIONHISTORYID");

            modelBuilder.HasSequence("EXCHANGERATEID");

            modelBuilder.HasSequence("EXTRACTCONFIGID");

            modelBuilder.HasSequence("EXTRACTLOOKUPID");

            modelBuilder.HasSequence("EXTRACTTABLEID");

            modelBuilder.HasSequence("EXTRACTTRANSFORMID");

            modelBuilder.HasSequence("EXTRACTTRIGGERFLAGID");

            modelBuilder.HasSequence("FIID");

            modelBuilder.HasSequence("FILEEVENTID");

            modelBuilder.HasSequence("FILEID");

            modelBuilder.HasSequence("FILEIMPORTID");

            modelBuilder.HasSequence("FPSID");

            modelBuilder.HasSequence("GLTRANSACTIONID");

            modelBuilder.HasSequence("HEATINGVALUEID");

            modelBuilder.HasSequence("HID");

            modelBuilder.HasSequence("HIERARCHYMBRRELID");

            modelBuilder.HasSequence("HIMESSAGEID");

            modelBuilder.HasSequence("HIMETERCONFIGID");

            modelBuilder.HasSequence("HIMETERSEQID");

            modelBuilder.HasSequence("HIOUTID");

            modelBuilder.HasSequence("HIOUTTPID");

            modelBuilder.HasSequence("HISECTIONID");

            modelBuilder.HasSequence("HITDDISPSTATUSID");

            modelBuilder.HasSequence("HITDPROPERTYID");

            modelBuilder.HasSequence("HITRANSACTIONDEFINITIONID");

            modelBuilder.HasSequence("HITRANSACTIONEVENTID");

            modelBuilder.HasSequence("HITRANSACTIONID");

            modelBuilder.HasSequence("HITRANSACTIONPROPERTYID");

            modelBuilder.HasSequence("HITRANSDEFRELID");

            modelBuilder.HasSequence("HIWIZARDID");

            modelBuilder.HasSequence("HIWIZARDSECTIONID");

            modelBuilder.HasSequence("HMBRAMID");

            modelBuilder.HasSequence("HMBRID");

            modelBuilder.HasSequence("HMBRPROPERTYID");

            modelBuilder.HasSequence("HPROPERTYID");

            modelBuilder.HasSequence("HUBROLEPROPERTYID");

            modelBuilder.HasSequence("HUBUSEREVENTID");

            modelBuilder.HasSequence("HUBUSERGROUPID");

            modelBuilder.HasSequence("IIDATAELEMENTID");

            modelBuilder.HasSequence("IIDATAELEMENTRELID");

            modelBuilder.HasSequence("IIDEPROPERTYID");

            modelBuilder.HasSequence("IIJOBID");

            modelBuilder.HasSequence("IIJOBPROPERTYID");

            modelBuilder.HasSequence("IIJOBRUNID");

            modelBuilder.HasSequence("IIJOBRUNMESSAGEID");

            modelBuilder.HasSequence("IIRECORDID");

            modelBuilder.HasSequence("IIRECORDSETID");

            modelBuilder.HasSequence("IIRPROPERTYID");

            modelBuilder.HasSequence("IIRSPROPERTYID");

            modelBuilder.HasSequence("INSTALMENTPLANEVENTID");

            modelBuilder.HasSequence("INTERESTCHARGEID");

            modelBuilder.HasSequence("INVADDRESSID");

            modelBuilder.HasSequence("INVADJINVOICEHISTORYID");

            modelBuilder.HasSequence("INVCHGAMTID");

            modelBuilder.HasSequence("INVENTORYID");

            modelBuilder.HasSequence("INVENTORYPPID");

            modelBuilder.HasSequence("INVOICEADJUSTMENTID");

            modelBuilder.HasSequence("INVOICECHARGEID");

            modelBuilder.HasSequence("INVOICECONSUMPTIONID");

            modelBuilder.HasSequence("INVOICEDATAID");

            modelBuilder.HasSequence("INVOICEDOCID");

            modelBuilder.HasSequence("INVOICEID");

            modelBuilder.HasSequence("INVOICEREADINGTOUID");

            modelBuilder.HasSequence("INVOICERELID");

            modelBuilder.HasSequence("INVPROPERTYID");

            modelBuilder.HasSequence("INVSTATUSHISTORYID");

            modelBuilder.HasSequence("JOBID");

            modelBuilder.HasSequence("JOBSTATUSID");

            modelBuilder.HasSequence("LFAPROPERTYID");

            modelBuilder.HasSequence("LFAREAID");

            modelBuilder.HasSequence("LOCATIONID");

            modelBuilder.HasSequence("LOCATIONOVERRIDEID");

            modelBuilder.HasSequence("LOCATIONPREFIXID");

            modelBuilder.HasSequence("LOCATIONPROPERTYID");

            modelBuilder.HasSequence("LOCCONTEXTID");

            modelBuilder.HasSequence("LOCHID");

            modelBuilder.HasSequence("LOCHMBRID");

            modelBuilder.HasSequence("LOCHMBRPROPERTYID");

            modelBuilder.HasSequence("LOOKUPCELLID");

            modelBuilder.HasSequence("LOOKUPID");

            modelBuilder.HasSequence("LOOKUPMEMBERID");

            modelBuilder.HasSequence("LSACCOUNTID");

            modelBuilder.HasSequence("LSEQUIPID");

            modelBuilder.HasSequence("LSEVENTID");

            modelBuilder.HasSequence("LSREGID");

            modelBuilder.HasSequence("LSSTATUSID");

            modelBuilder.HasSequence("MARKETINGMESSAGEID");

            modelBuilder.HasSequence("MESSAGEUSEID");

            modelBuilder.HasSequence("METERMODELID");

            modelBuilder.HasSequence("METERRANGEID");

            modelBuilder.HasSequence("METRICID");

            modelBuilder.HasSequence("METRICTYPEID");

            modelBuilder.HasSequence("MIRNADDRESSID");

            modelBuilder.HasSequence("MMPROPERTYID");

            modelBuilder.HasSequence("NOTECLASSIFICATIONCATID");

            modelBuilder.HasSequence("NOTECLASSIFICATIONGRPID");

            modelBuilder.HasSequence("NOTECLASSIFICATIONSUBCATID");

            modelBuilder.HasSequence("NOTEID");

            modelBuilder.HasSequence("NOTETEMPLATEID");

            modelBuilder.HasSequence("NOTETEMPLATEVERSIONID");

            modelBuilder.HasSequence("NOTETEXTID");

            modelBuilder.HasSequence("OFFERELIGIBILITYID");

            modelBuilder.HasSequence("OFFERID");

            modelBuilder.HasSequence("OFFEROTHERFEESID");

            modelBuilder.HasSequence("OFFERPROPERTYID");

            modelBuilder.HasSequence("OFFERSTENCILID");

            modelBuilder.HasSequence("ONLINEEVENTID");

            modelBuilder.HasSequence("ONLINEFORMDATAID");

            modelBuilder.HasSequence("PAYMENTPLANID");

            modelBuilder.HasSequence("PAYMENTPLANINSTALMENTID");

            modelBuilder.HasSequence("PAYMENTPLANTAXID");

            modelBuilder.HasSequence("PENDINGBILLADJUSTID");

            modelBuilder.HasSequence("PENSIONTYPECONFIGID");

            modelBuilder.HasSequence("PERIODID");

            modelBuilder.HasSequence("PGPROPERTYID");

            modelBuilder.HasSequence("PLSQL_PROFILER_RUNNUMBER");

            modelBuilder.HasSequence("POSTCODEDISTRIBUTORID");

            modelBuilder.HasSequence("PPPROPERTYID");

            modelBuilder.HasSequence("PPRULEID");

            modelBuilder.HasSequence("PQPRODUCTREFERENCEID");

            modelBuilder.HasSequence("PQRUNID");

            modelBuilder.HasSequence("PQRUNMESSAGEID");

            modelBuilder.HasSequence("PQSITEID");

            modelBuilder.HasSequence("PRICINGADJUSTMENTID");

            modelBuilder.HasSequence("PRODUCTGROUPID");

            modelBuilder.HasSequence("PRODUCTID");

            modelBuilder.HasSequence("PRODUCTMPID");

            modelBuilder.HasSequence("PRODUCTRATEID");

            modelBuilder.HasSequence("PRODUCTRELID");

            modelBuilder.HasSequence("PRODUCTRELPROPERTYID");

            modelBuilder.HasSequence("PROPERTYID");

            modelBuilder.HasSequence("PROPERTYUSEID");

            modelBuilder.HasSequence("PROSPECTADDRESSID");

            modelBuilder.HasSequence("PROSPECTCONTACTID");

            modelBuilder.HasSequence("PROSPECTID");

            modelBuilder.HasSequence("PROSPECTPERMISSIONID");

            modelBuilder.HasSequence("PROSPECTSTAGINGERRORID");

            modelBuilder.HasSequence("PROSPECTSTAGINGID");

            modelBuilder.HasSequence("PSID");

            modelBuilder.HasSequence("PSMBRID");

            modelBuilder.HasSequence("PSSMBRID");

            modelBuilder.HasSequence("QUOTENUMBER");

            modelBuilder.HasSequence("RATESHEETDISTRIBUTORID");

            modelBuilder.HasSequence("RATESHEETID");

            modelBuilder.HasSequence("RATESHEETPDFID");

            modelBuilder.HasSequence("RATESHEETSTENCILKEYID");

            modelBuilder.HasSequence("RATINGPERIODID");

            modelBuilder.HasSequence("RATINGPLANEVENTID");

            modelBuilder.HasSequence("RATINGPLANID");

            modelBuilder.HasSequence("RBPROPERTYID");

            modelBuilder.HasSequence("READINGACTIONID");

            modelBuilder.HasSequence("READINGACTIONTOUID");

            modelBuilder.HasSequence("READINGDUMBESTID");

            modelBuilder.HasSequence("READINGDUMBID");

            modelBuilder.HasSequence("READINGEVENTID");

            modelBuilder.HasSequence("READINGEXTRACTID");

            modelBuilder.HasSequence("READINGRETIREID");

            modelBuilder.HasSequence("READINGRETIRETOUID");

            modelBuilder.HasSequence("READINGTOUERRORID");

            modelBuilder.HasSequence("READINGTOUESTID");

            modelBuilder.HasSequence("READINGTOUID");

            modelBuilder.HasSequence("READINGTYPEID");

            modelBuilder.HasSequence("READINGUSERDATAID");

            modelBuilder.HasSequence("READINGUSERDATATOUID");

            modelBuilder.HasSequence("RECEIPTALLOCID");

            modelBuilder.HasSequence("RECEIPTBATCHID");

            modelBuilder.HasSequence("RECEIPTID");

            modelBuilder.HasSequence("RECEIPTPROPERTYID");

            modelBuilder.HasSequence("RECENTITEMID");

            modelBuilder.HasSequence("RECONCCHARGEID");

            modelBuilder.HasSequence("REPORTID");

            modelBuilder.HasSequence("REPORTPROPERTYID");

            modelBuilder.HasSequence("REPORTRUNID");

            modelBuilder.HasSequence("RERATEEVENTID");

            modelBuilder.HasSequence("RERULEID");

            modelBuilder.HasSequence("REWARDPLANEVENTID");

            modelBuilder.HasSequence("REWARDPLANID");

            modelBuilder.HasSequence("REWARDTYPEID");

            modelBuilder.HasSequence("RMUSEID");

            modelBuilder.HasSequence("ROLEID");

            modelBuilder.HasSequence("RPPROPERTYID");

            modelBuilder.HasSequence("RPSUMMARYID");

            modelBuilder.HasSequence("RPUNITSPUNITID");

            modelBuilder.HasSequence("RRATTACHMENTID");

            modelBuilder.HasSequence("RRPROPERTYID");

            modelBuilder.HasSequence("RULEATTRIBUTEID");

            modelBuilder.HasSequence("RULECOMPOPID");

            modelBuilder.HasSequence("RULECRITERIAGROUPID");

            modelBuilder.HasSequence("RULECRITERIONID");

            modelBuilder.HasSequence("RULEENGINERULEID");

            modelBuilder.HasSequence("RULESOURCEID");

            modelBuilder.HasSequence("RULEVERSIONID");

            modelBuilder.HasSequence("RWPPROPERTYID");

            modelBuilder.HasSequence("SAID");

            modelBuilder.HasSequence("SALESCHANNELOFFERID");

            modelBuilder.HasSequence("SAVEDQUERYID");

            modelBuilder.HasSequence("SCHEDULECONTROLID");

            modelBuilder.HasSequence("SCHEDULEGROUPID");

            modelBuilder.HasSequence("SCHEDULEID");

            modelBuilder.HasSequence("SCID");

            modelBuilder.HasSequence("SCRIPTLIBRARYID");

            modelBuilder.HasSequence("SEASONDETAILID");

            modelBuilder.HasSequence("SEASONID");

            modelBuilder.HasSequence("SEASONSETID");

            modelBuilder.HasSequence("SEPI18548BATCHRUNID");

            modelBuilder.HasSequence("SETTLEMENTDETAILID");

            modelBuilder.HasSequence("SETTLEMENTINVOICEACTIONID");

            modelBuilder.HasSequence("SETTLEMENTINVOICEID");

            modelBuilder.HasSequence("SGPROPERTYID");

            modelBuilder.HasSequence("SITEACCESSID");

            modelBuilder.HasSequence("SOCOMPLETIONID");

            modelBuilder.HasSequence("SPNETWORKDETAILID");

            modelBuilder.HasSequence("SPNETWORKID");

            modelBuilder.HasSequence("SPPROPERTYID");

            modelBuilder.HasSequence("SQLT$STATEMENT_SEQ");

            modelBuilder.HasSequence("STENCILATTRIBUTEID");

            modelBuilder.HasSequence("STENCILID");

            modelBuilder.HasSequence("STENCILVERSIONID");

            modelBuilder.HasSequence("STRUCTID");

            modelBuilder.HasSequence("SUPPLYPOINTID");

            modelBuilder.HasSequence("SYS$AUDITREPORT");

            modelBuilder.HasSequence("SYS$DISABLELOCK");

            modelBuilder.HasSequence("SYSTEMLOCKID");

            modelBuilder.HasSequence("SYSTEMPROPERTYID");

            modelBuilder.HasSequence("TAXCHARGEID");

            modelBuilder.HasSequence("TAXRATEID");

            modelBuilder.HasSequence("THIRDPARTYID");

            modelBuilder.HasSequence("TIMEBANDID");

            modelBuilder.HasSequence("TIMERANGEID");

            modelBuilder.HasSequence("TIMESETID");

            modelBuilder.HasSequence("TIMESETVERSIONID");

            modelBuilder.HasSequence("TPPROPERTYID");

            modelBuilder.HasSequence("TPSTAGEID");

            modelBuilder.HasSequence("TREATMENTEVENTID");

            modelBuilder.HasSequence("TREATMENTPLANID");

            modelBuilder.HasSequence("TREATMENTSTAGEID");

            modelBuilder.HasSequence("TRIADPERIODID");

            modelBuilder.HasSequence("TRIADRULEID");

            modelBuilder.HasSequence("UBUPSID");

            modelBuilder.HasSequence("UEETPROPERTYID");

            modelBuilder.HasSequence("UMSDEVICEID");

            modelBuilder.HasSequence("UMSLOADID");

            modelBuilder.HasSequence("UPSBUID");

            modelBuilder.HasSequence("UPSID");

            modelBuilder.HasSequence("USAGEBASECHARGEID");

            modelBuilder.HasSequence("USAGEDELETEEVENTID");

            modelBuilder.HasSequence("USAGEDETAILID");

            modelBuilder.HasSequence("USAGEDISCOUNTID");

            modelBuilder.HasSequence("USAGEERROREXCEPTIONTYPEID");

            modelBuilder.HasSequence("USAGEFILEID");

            modelBuilder.HasSequence("USAGEFILEPROPERTYID");

            modelBuilder.HasSequence("USAGEPROFILEID");

            modelBuilder.HasSequence("USAGEPROFILEPERIODID");

            modelBuilder.HasSequence("USAGERATINGCONTROLID");

            modelBuilder.HasSequence("USAGERATINGEVENTID");

            modelBuilder.HasSequence("USAGETIMECHARGEID");

            modelBuilder.HasSequence("USERFAVID");

            modelBuilder.HasSequence("USERID");

            modelBuilder.HasSequence("USERPREFID");

            modelBuilder.HasSequence("USERPROPERTYID");

            modelBuilder.HasSequence("USERSEARCHID");

            modelBuilder.HasSequence("USERSESSIONID");

            modelBuilder.HasSequence("VERSIONCONTROLID");

            modelBuilder.HasSequence("VERSIONID");

            modelBuilder.HasSequence("WFGROUPID");

            modelBuilder.HasSequence("WFGROUPPROPERTYID");

            modelBuilder.HasSequence("WFGROUPSTATID");

            modelBuilder.HasSequence("WFSKILLSETID");

            modelBuilder.HasSequence("XSCHEMATRANSVERID");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
