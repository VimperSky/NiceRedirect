export interface RedirectData {
  target: string;
  type: RedirectType;
  password: string | null;
}

export enum RedirectType {
  Standard,
  WithPassword
}

export interface Redirect {
  key: string;
  data: RedirectData;
}
