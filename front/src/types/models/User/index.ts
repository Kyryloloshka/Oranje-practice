export type Roles = ("Admin" | "User")[];

export type UserProfileToken = {
  userName: string;
  email: string;
  token: string;
  roles: Roles;
};

export type UserProfile = {
  username: string;
  email: string;
  roles: Roles;
};
