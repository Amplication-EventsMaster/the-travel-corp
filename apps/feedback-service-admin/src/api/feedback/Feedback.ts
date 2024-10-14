import { Review } from "../review/Review";

export type Feedback = {
  booking: string | null;
  comments: string | null;
  createdAt: Date;
  id: string;
  rating: number | null;
  remarks: string | null;
  reviews?: Array<Review>;
  updatedAt: Date;
};
