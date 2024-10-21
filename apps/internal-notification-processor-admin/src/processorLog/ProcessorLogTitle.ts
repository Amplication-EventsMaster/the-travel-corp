import { ProcessorLog as TProcessorLog } from "../api/processorLog/ProcessorLog";

export const PROCESSORLOG_TITLE_FIELD = "id";

export const ProcessorLogTitle = (record: TProcessorLog): string => {
  return record.id?.toString() || String(record.id);
};
