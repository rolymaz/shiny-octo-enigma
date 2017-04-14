using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TST.Services
{

    public enum OrderQueueEnum
    {
        None = 0,
        Opened = 1,
        NewOrder = 2,
        PendingFix = 3,
        PendingCompliance = 4,
        PendingComplianceFix = 5,
        PendingPostVet = 6,
        PendingPostVetFix = 7,
        PendingCapture = 8,
        PendingCaptureFix = 9,
        PendingDelivery = 10,
        PendingDeliveryFix = 11,
        PendingActivation = 12,
        PendingCancel = 13,
        Closed = 14,
        

    }


    public enum ImportStatus
    {
        None = 0,
        New = 1,
        Processed = 2,
        Complete = 3,
        Discarded = 4,
        Errors = 5

    }

    public enum WorkflowEnum
    {
        Test = 0,
        ConsumerMobile = 1,
        ConsumerFixedLine = 2,
        BusinessMobile = 3,
        BusinessFixedLine = 4,
        Online=5
    }

    public enum OrderChangeReponseEnum
    {
        Success,
        Fail,
        Error
    }

    public enum TriggerEnum
    {
        Open = 0,
        Pass = 1,
        Fail =2,
        Cancel =3,
        Close =4

    }
}