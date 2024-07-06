import { createSlice } from "@reduxjs/toolkit";

interface AdminState {}

const initialState: AdminState = {};

const slice = createSlice({
  name: "admin",
  initialState,
  reducers: {},
});

export const { reducer: adminReducer, actions: adminActions } = slice;
