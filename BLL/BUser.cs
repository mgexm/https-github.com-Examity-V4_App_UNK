using System;
using BusinessEntities;
using DAL;

namespace BLL
{
    public class BUser
    {
        #region BValidateUser
        /// <summary>
        /// Validate User
        /// </summary>
        /// <param name="objBEUser"></param>
        public void BValidateUser(BEUser objBEUser)
        {
            try
            {
                new DUser().DValidateUser(objBEUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BChangePassword
        public void BChangePassword(BEUser objBEUser)
        {
            try
            {
                new DUser().DChangePassword(objBEUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BGetTimeZone
        public void BGetTimeZone(BEUser objBEUser)
        {
            try
            {
                new DUser().DGetTimeZone(objBEUser);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGenderList
        public void BGenderList(BEUser objBEUser)
        {
            try
            {
                new DUser().DGenderList(objBEUser);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion


        #region BUpdateTimeZone
        public void BUpdateTimeZone(BEUser objBEUser)
        {
            try
            {
                new DUser().DUpdateTimeZone(objBEUser);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BGetProfileDetails
        public void BGetProfileDetails(BEUser objBEUser)
        {
            try
            {
                new DUser().DGetProfileDetails(objBEUser);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public void BGetProfileExamiKeyDetails(BEUser objBEUser)
        {
            try
            {
                new DUser().DGetProfileExamiKeyDetails(objBEUser);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BForgotPassword
        public void BForgotPassword(BEUser objBEUser)
        {
            try
            {
                new DUser().DForgotPassword(objBEUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BValidateUser
        /// <summary>
        /// Validate User
        /// </summary>
        /// <param name="objBEUser"></param>
        public void BFindUser(BEUser objBEUser)
        {
            try
            {
                new DUser().DFindUser(objBEUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BUpdateLoginFlag
        public void BUpdateLoginFlag(BEUser objBEUser)
        {
            try
            {
                new DUser().DUpdateLoginFlag(objBEUser);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        #endregion

        #region BCanvasLogin
        public void BCanvasLogin(BEUser objBEUser)
        {
            try
            {
                new DUser().DCanvasLogin(objBEUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BLMSLogin
        public void BLMSLogin(BEUser objBEUser)
        {
            try
            {
                new DUser().DLMSLogin(objBEUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region BCommonUpdateTimeZone
        public void BCommonUpdateTimeZone(BEUser objBEUser)
        {
            try
            {
                new DUser().DCommonUpdateTimeZone(objBEUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BValidatePoretalUser
        /// <summary>
        /// Validate Portal User
        /// </summary>
        /// <param name="objBEUser"></param>
        public void BValidatePortalUser(BEUser objBEUser)
        {
            try
            {
                new DUser().DValidatePortalUser(objBEUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public void BSSO_ADDUSER(BEUser objBEUser, string LMS)
        {
            try
            {
                new DUser().DSSO_ADDUSER(objBEUser, LMS);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BSSO_SaveToken(string emailAddress, string token)
        {
            try
            {
                new DUser().DSSO_SaveToken(emailAddress, token);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public void BPasswordExists(BEUser objBEUser)
        //{
        //    try
        //    {
        //        new DUser().DPasswordExists(objBEUser);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
