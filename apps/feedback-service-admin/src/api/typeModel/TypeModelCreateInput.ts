import { ReviewCreateNestedManyWithoutTypeModelsInput } from "./ReviewCreateNestedManyWithoutTypeModelsInput";

export type TypeModelCreateInput = {
  name?: string | null;
  reviews?: ReviewCreateNestedManyWithoutTypeModelsInput;
};
