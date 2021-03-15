﻿
using Nagarro.BookEventManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEventManagement.Business
{
    public class EventBDC:BDCBase,IEventBDC
    {
        private readonly IDACFactory dacFactory;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public EventBDC()
            : base(BDCType.EventBDC)
        {
            dacFactory = DACFactory.Instance;
        }

        public EventBDC(IDACFactory dacFactory)
            : base(BDCType.EventBDC)
        {
            this.dacFactory = dacFactory;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EventDTO"></param>
        /// <returns></returns>
        public OperationResult<EventDTO> CreateEvent(EventDTO eventDTO)
        {
            OperationResult<EventDTO> retVal = null;
            try
            {
                NagarroSampleValidationResult validationResult = Validator<EventValidator, EventDTO>.Validate(eventDTO);
                if (validationResult.IsValid)
                {
                    IEventDAC eventDAC = (IEventDAC)dacFactory.Create(DACType.EventDAC);
                    EventDTO resultDTO = eventDAC.CreateEvent(eventDTO);
                    if (resultDTO != null)
                    {
                        retVal = OperationResult<EventDTO>.CreateSuccessResult(resultDTO);
                    }
                    else
                    {
                        retVal = OperationResult<EventDTO>.CreateFailureResult("Failed!");
                    }
                }
                else
                {
                    retVal = OperationResult<EventDTO>.CreateFailureResult(validationResult);
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<EventDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<EventDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public void DeleteEvent(EventDTO EventDTO)
        {
            IEventDAC eventDAC = (IEventDAC)dacFactory.Create(DACType.EventDAC);
            eventDAC.DeleteEvent(EventDTO);
        }

        public EventDTO GetEvent(int EventId)
        {
            IEventDAC eventDAC = (IEventDAC)dacFactory.Create(DACType.EventDAC);
            return eventDAC.GetEvent(EventId);
        }

       
        #endregion

        #region Private Methods

        #endregion
        public List<EventDTO> GetEvents()
        {
            IEventDAC eventDAC = (IEventDAC)dacFactory.Create(DACType.EventDAC);
            List<EventDTO> result = eventDAC.GetEvents();
            return result;
        }

        public void UpdateEvent(EventDTO EventDTO)
        {
            IEventDAC eventDAC = (IEventDAC)dacFactory.Create(DACType.EventDAC);
            eventDAC.UpdateEvent(EventDTO);
        }
    }
}
