import { TypeModel as TTypeModel } from "../api/typeModel/TypeModel";

export const TYPEMODEL_TITLE_FIELD = "name";

export const TypeModelTitle = (record: TTypeModel): string => {
  return record.name?.toString() || String(record.id);
};
