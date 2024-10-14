import { Review } from "../review/Review";

export type TypeModel = {
  createdAt: Date;
  id: string;
  name: string | null;
  reviews?: Array<Review>;
  updatedAt: Date;
};
