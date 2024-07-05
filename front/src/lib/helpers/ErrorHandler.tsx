import axios from "axios";
import { toast } from "react-toastify";

export const handleError = (error: any) => {
  if (axios.isAxiosError(error)) {
    let err = error.response;
    if (Array.isArray(err?.data.errors)) {
      for (const val of err.data.errors) {
        toast.warning(val.descrition);
      }
    } else if (typeof err?.data.errors === "object") {
      for (const key in err.data.errors) {
        toast.warning(err.data.errors[key][0]);
      }
    } else if (err?.data) {
      toast.warning(err.data);
    } else if (err?.status === 401) {
      toast.warning("Please login to continue");
      window.history.pushState({}, "LoginPage", "/login");
    } else if (err) {
      toast.warning(err.data);
    }
  }
};
