import { ProcessorLogWhereInput } from "./ProcessorLogWhereInput";
import { ProcessorLogOrderByInput } from "./ProcessorLogOrderByInput";

export type ProcessorLogFindManyArgs = {
  where?: ProcessorLogWhereInput;
  orderBy?: Array<ProcessorLogOrderByInput>;
  skip?: number;
  take?: number;
};
