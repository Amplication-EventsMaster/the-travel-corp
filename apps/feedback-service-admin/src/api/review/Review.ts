import { Feedback } from "../feedback/Feedback";
import { TypeModel } from "../typeModel/TypeModel";

export type Review = {
  content: string | null;
  createdAt: Date;
  feedback?: Feedback | null;
  id: string;
  title: string | null;
  typeField?: TypeModel | null;
  updatedAt: Date;
};
