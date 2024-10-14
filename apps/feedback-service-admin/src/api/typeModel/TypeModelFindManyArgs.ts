import { TypeModelWhereInput } from "./TypeModelWhereInput";
import { TypeModelOrderByInput } from "./TypeModelOrderByInput";

export type TypeModelFindManyArgs = {
  where?: TypeModelWhereInput;
  orderBy?: Array<TypeModelOrderByInput>;
  skip?: number;
  take?: number;
};
